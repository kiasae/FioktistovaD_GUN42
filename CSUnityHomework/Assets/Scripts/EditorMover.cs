using UnityEngine;

namespace DefaultNamespace
{
	
	[RequireComponent(typeof(PositionSaver))]
	public class EditorMover : MonoBehaviour
	{
		private PositionSaver _save;
		private float _currentDelay;

		//todo comment: Что произойдёт, если _delay > _duration?
		//запишется только первая позиция, т.к. таймер _duration закончится раньше чем _delay и скрипт завершит работу
		[Range(0.2f, 1.0f)]
		private float _delay = 0.5f;

		[Min(0.2f)]
		private float _duration = 5f;

		private void Start()
		{
			//todo comment: Почему этот поиск производится здесь, а не в начале метода Update?
			//Для улучшения производительности. GetComponent будет производится только один раз в методе Start, а не постоянно как в Update
			_save = GetComponent<PositionSaver>();
			_save.Records.Clear();

			if (_duration<= _delay)
			{
				_duration = _delay * 5f;
			}
		}

		private void Update()
		{
			_duration -= Time.deltaTime;
			if (_duration <= 0f)
			{
				enabled = false;
				Debug.Log($"<b>{name}</b> finished", this);
				return;
			}
			
			//todo comment: Почему не написать (_delay -= Time.deltaTime;) по аналогии с полем _duration?
			//потому что _currentDelay это обратный отсчет, а _delay должен оставаться неподвижным
			_currentDelay -= Time.deltaTime;
			if (_currentDelay <= 0f)
			{
				_currentDelay = _delay;
				_save.Records.Add(new PositionSaver.Data
				{
					Position = transform.position,
					//todo comment: Для чего сохраняется значение игрового времени?
					//чтобы правильно воспроизвести записанное движение с теми же таймингами
					Time = Time.time,
				});
			}
		}
	}
}