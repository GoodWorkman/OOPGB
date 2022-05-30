using System.Collections;
using System;
using UnityEngine;

namespace Maze
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable
    {
        private IExecute[] _interactiveObject;
        private int _index = -1;


        public IExecute this[int curr]
        {
            get => _interactiveObject[curr];
            private set => _interactiveObject[curr] = value;
        }

        public void AddExecuteObject(IExecute execute)
        {
            if (_interactiveObject == null)
            {
                _interactiveObject = new[] {execute};
                return;
            }
            
            Array.Resize(ref _interactiveObject, Lenght+1);
            _interactiveObject[Lenght - 1] = execute;
        }

        public int Lenght => _interactiveObject.Length;
        
        public bool MoveNext()
        {
            if (_index == Lenght - 1)
            {
                Reset();
                return false;
            }
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current => _interactiveObject[_index];
        
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}

