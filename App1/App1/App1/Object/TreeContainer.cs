using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App1.Object
{
    class TreeContainer: ObjectContainer<Tree>
    {
        public TreeContainer(): base()
        {
            _object = new List<Tree>();
        }

        public Tree Last => _object.LastOrDefault();
        public Tree secondLast => (_object.Count > 1) ? _object[_object.Count - 2] : null;

        // gọi Rotation => thằng cuối cùng rotate
        public void rotation()
        {
            _object[_object.Count - 1].rotation();
        }

        public void updateHeight(int speed)
        {
            _object[_object.Count - 1].updateHeight(speed);
        }
    }
}
