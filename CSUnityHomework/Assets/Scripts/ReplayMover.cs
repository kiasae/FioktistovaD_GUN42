using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(PositionSaver))]
	public class ReplayMover : MonoBehaviour
	{
		private PositionSaver _save;

		private int _index;
		private PositionSaver.Data _prev;
		private float _duration;

		private void Start()
		{
			//todo comment: зачем нужны эти проверки?
			//они проверяют, есть ли вообще нужные данные. если их нет, то код не воспроизведется
			if (!TryGetComponent(out _save) || _save.Records.Count == 0)
			{
				Debug.LogError("Records incorrect value", this);
				//todo comment: Для чего выключается этот компонент?
				//чтобы остановить Update () для оптимизации и чтобы избежать ошибок
				enabled = false;
			}
		}

		private void Update()
		{
			var curr = _save.Records[_index];
			//todo comment: Что проверяет это условие (с какой целью)? 
			//проверяет наступило ли время текущей записи и если да, то переходит к следующему действию
			if (Time.time > curr.Time)
			{
				_prev = curr;
				_index++;
                //todo comment: Для чего нужна эта проверка?
                //проверяет не вышли ли мы за пределы списка после _index. если да,  то отключает компонент и выводит сообщение о завершении
                if (_index >= _save.Records.Count)
				{
					enabled = false;
					Debug.Log($"<b>{name}</b> finished", this);
				}
			}
			//todo comment: Для чего производятся эти вычисления (как в дальнейшем они применяются)?
			//они вычисляют сколько времени прошло с предыдущей точки до текущей. используется, чтобы движение между точками было более плавное
			var delta = (Time.time - _prev.Time) / (curr.Time - _prev.Time);
			//todo comment: Зачем нужна эта проверка?
			//проверка от деления на 0 чтобы не сломать код
			if (float.IsNaN(delta)) delta = 0f;
			//todo comment: Опишите, что происходит в этой строчке так подробно, насколько это возможно
			//Она берет предыдущую точку, берет следующую и берет насколько мы продвинулись от первой точки ко второй. потом полученная позиция присваивается объекту. благодаря этим данным объект плавно перемещается от одной точки к другой
			transform.position = Vector3.Lerp(_prev.Position, curr.Position, delta);
		}
	}
}