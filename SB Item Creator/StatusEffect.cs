using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class StatusEffect
    {
        private string kind;
        private float amount;
        private int level;
        public StatusEffect(string Kind, float Amount) {
            kind = Kind;
            amount = Amount;
        }

        public string GetKind(){
        return kind;
        }
        public float GetAmount(){
            return amount;
        }
    }
}
