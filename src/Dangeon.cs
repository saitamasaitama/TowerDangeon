using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/////データ構造

public struct V3
{
  public int x;
  public int y;
  public int z;

}


////

public class Dangeon
{
  public List<DangeonFloor> floors = new List<DangeonFloor>();



  public static Dangeon Generate()
  {
    var result = new Dangeon();

    result.floors = Enumerable.Range(0, 10).Select(index => new DangeonFloor()).ToList();


    //接続部の作成

    for (int i = 0; i < 10; i++)
    {
      DangeonFloor floor = result.floors[i];
      //前のフロアへの接続部
      if (0 < i)
      {


        floor["Prev"] = result.floors[i - 1];
        //適当に階段を生成
        floor.Portal[new V3()
        {
          x = 1,
          y = 2,
          z = 3
        }] = "Prev";
      }

      //次のフロアへの接続部
      if (i < 10)
      {
        floor["Next"] = result.floors[i + 1];
      }



    }



    return result;
  }
}



public class DangeonFloor : Dictionary<string, DangeonFloor>
{
  public Dictionary<V3, string> Portal = new Dictionary<V3, string>();

  public DangeonFloor Next => this["Next"];
  public DangeonFloor Prev => this["Prev"];

}
