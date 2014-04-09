using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    interface AbstractBeing
    {
        void castAttack(AbstractBeing other);
        void attackedBy(AbstractBeing other);
        void heals(int amount);
    }
}
