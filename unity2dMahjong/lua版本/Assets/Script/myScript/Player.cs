using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
   public class Player
    {
        private string uName = null;
        private string cName = null;
        private string image = null;
        private int money = 0;
        private string DuanWei = null;
        private string MyText = null;
        private int pos = 0;
        public static Player play = null;
        public Player()
        {
            
        }

        public static Player SharPlayer()
        {
            if (play == null) play = new Player();
            return play;
        }

        public string UName
        {
            get
            {
                return uName;
            }

            set
            {
                uName = value;
            }
        }

        public string CName
        {
            get
            {
                return cName;
            }

            set
            {
                cName = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public string DuanWei1
        {
            get
            {
                return DuanWei;
            }

            set
            {
                DuanWei = value;
            }
        }

        public string MyText1
        {
            get
            {
                return MyText;
            }

            set
            {
                MyText = value;
            }
        }

    public int Pos
    {
        get
        {
            return pos;
        }

        set
        {
            pos = value;
        }
    }
}

