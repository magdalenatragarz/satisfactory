using System;
using System.Collections.Generic;
using System.Text;

namespace Satisfactory
{
    public class Item
    {
        public ItemType type;
        public int quantity;

        public Item(ItemType type, int quantity)
        {
            this.type = type;
            this.quantity = quantity;
        }
    }
}
