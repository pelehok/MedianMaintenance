using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance.Models
{
    class MediumElement
    {
        private List<Key> _medians;
        private MaxHeap _maxHeap;
        private MinHeap _minHeap;

        public MediumElement(List<Key> keys)
        {
            int maxN = keys.Count/2 + 2;

            _maxHeap = new MaxHeap(maxN);
            _minHeap = new MinHeap(maxN);
            _medians = new List<Key>();
            CalculateMedians(keys);
        }

        private void CalculateMedians(List<Key> keys)
        {
            FirstAdd(keys[0], keys[1]);

            for(int i = 2; i < keys.Count; i++)
            {
                Key item = keys[i];

                if (item > _minHeap.Peek())
                {
                    _minHeap.Insert(item);
                }
                else
                {
                    _maxHeap.Insert(item);
                }
                CheckLenght();
                CalculateMedian();
            }
        }

        public int GetMedian()
        {
            int s = 0;
            for(int i = 0; i < _medians.Count; i++)
            {
                s += _medians[i].KeyValue;
            }

            return s % 10000;
        }

        private void CalculateMedian()
        {
            int lenght = _maxHeap.Size() + _minHeap.Size();

            if (lenght % 2 == 0)
            {
                _medians.Add(_maxHeap.Peek());
            }
            else
            {
                if (_maxHeap.Size() > _minHeap.Size())
                {
                    _medians.Add(_maxHeap.Peek());
                }
                else
                {
                    _medians.Add(_minHeap.Peek());
                }
            }
        }

        private void CheckLenght()
        {
            int diff = Math.Abs(_maxHeap.Size() - _minHeap.Size());
            if (diff >= 2)
            {
                if (_maxHeap.Size() > _minHeap.Size())
                {
                    _minHeap.Insert(_maxHeap.DelMax());
                }
                else
                {
                    _maxHeap.Insert(_minHeap.DelMin());
                }
            }
        }

        private void FirstAdd(Key first, Key second)
        {
            _medians.Add(first);

            if (first < second)
            {
                _maxHeap.Insert(first);
                _minHeap.Insert(second);
            }
            else
            {
                _minHeap.Insert(first);
                _maxHeap.Insert(second);
            }
            _medians.Add(_maxHeap.Peek());
        }
    }
}
