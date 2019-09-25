using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class User
{
    private string uName;
    private string cName;
    private string image;
    private int ready=-1;
    private int pos = 0;

    public User(string uName, string cName, string image, int ready, int pos)
    {
        this.uName = uName;
        this.cName = cName;
        this.image = image;
        this.Ready = ready;
        this.pos = pos;
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

    public int Ready
    {
        get
        {
            return ready;
        }

        set
        {
            ready = value;
        }
    }
}

