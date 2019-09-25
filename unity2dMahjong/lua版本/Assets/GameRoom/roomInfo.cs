using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
       四川麻将
       时间：2017.6.12
       作者：昂
       版本：2.9

*/

public class roomInfo
{
    private int roomId = 0;

    private int gameCount = 0;

    private int gamePlayer = 0;

    private string dqHsz = null;

    private int Fs = 0;

    private int myPos = 0;

    private List<User> userList = new List<User>();
    
    public void addUser(User user)
    {
        userList.Add(user);
        if(user.UName==Player.SharPlayer().UName)
        {
            myPos = user.Pos;
        }
    }

    public User[] getUser()
    {
        return userList.ToArray();
    }

    public User sharUser(string uName)
    {
        User u = null;
        for(int i=0;i<userList.Count;i++)
        {
            if(userList[i].UName==uName)
            {
                u = userList[i];
                break;
            }
        }
        return u;
    }
    public void removeUser(int index)
    {
        userList.RemoveAt(index);
    }
    public int GameCount
    {
        get
        {
            return gameCount;
        }

        set
        {
            gameCount = value;
        }
    }

    public int GamePlayer
    {
        get
        {
            return gamePlayer;
        }

        set
        {
            gamePlayer = value;
        }
    }

    public string DqHsz
    {
        get
        {
            return dqHsz;
        }

        set
        {
            dqHsz = value;
        }
    }

    public int Fs1
    {
        get
        {
            return Fs;
        }

        set
        {
            Fs = value;
        }
    }

    public int RoomId
    {
        get
        {
            return roomId;
        }

        set
        {
            roomId = value;
        }
    }
}
