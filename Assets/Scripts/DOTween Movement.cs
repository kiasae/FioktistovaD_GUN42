using UnityEngine;
using DG.Tweening;

public class CharacterPathMover : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float duration = 6f;
    [SerializeField] private float startDelay = 1f;
    [SerializeField] private int loops = -1;
    [SerializeField] private LoopType loopType = LoopType.Yoyo;
    [SerializeField] private Ease ease = Ease.InOutSine;

    [SerializeField] private Renderer characterRenderer;
    [SerializeField] private Color targetColor = Color.red;
    [SerializeField] private float scaleMultiplier = 1.5f;
    [SerializeField] private ParticleSystem dustEffect;

    private Sequence sequence;

    private void Start()
    {
        // превращаю трансформы точек в массив позиций
        Vector3[] path = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
            path[i] = waypoints[i].position;

        // Sequence позволяет запускать несколько твинов одновременно
        sequence = DOTween.Sequence();

        // запускаем движение по пути
        sequence.Append(transform.DOPath(path, duration, PathType.CatmullRom).SetEase(ease).SetLookAt(0.01f));  // персонаж поворачивается по ходу движения

        // масштаб увеличивается и возвращается (Join = параллельно с движением)
        sequence.Join(
            transform.DOScale(transform.localScale * scaleMultiplier, duration / 2f)
                     .SetLoops(2, LoopType.Yoyo)
        );

        // смена цвета за время движения
        if (characterRenderer != null)
            sequence.Join(characterRenderer.material.DOColor(targetColor, duration));

        //настройки всей последовательности
        sequence.SetDelay(startDelay)
                .SetLoops(loops, loopType)
                .OnStart(() => { if (dustEffect != null) dustEffect.Play(); })  // пыль при старте
                .OnKill(() => { if (dustEffect != null) dustEffect.Stop(); });  // стоп при уничтожении
    }

    private void OnDestroy()
    {
        //убиваем твин, чтобы не было ошибок после удаления объекта
        sequence.Kill();
    }
}