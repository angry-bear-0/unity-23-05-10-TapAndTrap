using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppNodeMD
{
    public static AppMapInfo[] mapData = {
        //round 1
        new AppMapInfo(0, 12, 0.455f, new AppNodeInfo[]{
            new AppNodeInfo(0, new int[]{11}, new int[]{1}, new Vector3[]{AppUtil.PolarToVec(0.455f, 0), AppUtil.PolarToVec(0.455f, 10), AppUtil.PolarToVec(0.455f, 20), AppUtil.PolarToVec(0.455f, 30)}),
            new AppNodeInfo(1, new int[]{0}, new int[]{2}, new Vector3[]{AppUtil.PolarToVec(0.455f, 30), AppUtil.PolarToVec(0.455f, 40), AppUtil.PolarToVec(0.455f, 50), AppUtil.PolarToVec(0.455f, 60)}),
            new AppNodeInfo(2, new int[]{1}, new int[]{3}, new Vector3[]{AppUtil.PolarToVec(0.455f, 60), AppUtil.PolarToVec(0.455f, 70), AppUtil.PolarToVec(0.455f, 80), AppUtil.PolarToVec(0.455f, 90)}),
            new AppNodeInfo(3, new int[]{2}, new int[]{4}, new Vector3[]{AppUtil.PolarToVec(0.455f, 90), AppUtil.PolarToVec(0.455f, 100), AppUtil.PolarToVec(0.455f, 110), AppUtil.PolarToVec(0.455f, 120)}),
            new AppNodeInfo(4, new int[]{3}, new int[]{5}, new Vector3[]{AppUtil.PolarToVec(0.455f, 120), AppUtil.PolarToVec(0.455f, 130), AppUtil.PolarToVec(0.455f, 140), AppUtil.PolarToVec(0.455f, 150)}),
            new AppNodeInfo(5, new int[]{4}, new int[]{6}, new Vector3[]{AppUtil.PolarToVec(0.455f, 150), AppUtil.PolarToVec(0.455f, 160), AppUtil.PolarToVec(0.455f, 170), AppUtil.PolarToVec(0.455f, 180)}),
            new AppNodeInfo(6, new int[]{5}, new int[]{7}, new Vector3[]{AppUtil.PolarToVec(0.455f, 180), AppUtil.PolarToVec(0.455f, 190), AppUtil.PolarToVec(0.455f, 200), AppUtil.PolarToVec(0.455f, 210)}),
            new AppNodeInfo(7, new int[]{6}, new int[]{8}, new Vector3[]{AppUtil.PolarToVec(0.455f, 210), AppUtil.PolarToVec(0.455f, 220), AppUtil.PolarToVec(0.455f, 230), AppUtil.PolarToVec(0.455f, 240)}),
            new AppNodeInfo(8, new int[]{7}, new int[]{9}, new Vector3[]{AppUtil.PolarToVec(0.455f, 240), AppUtil.PolarToVec(0.455f, 250), AppUtil.PolarToVec(0.455f, 260), AppUtil.PolarToVec(0.455f, 270)}),
            new AppNodeInfo(9, new int[]{8}, new int[]{10}, new Vector3[]{AppUtil.PolarToVec(0.455f, 270), AppUtil.PolarToVec(0.455f, 280), AppUtil.PolarToVec(0.455f, 290), AppUtil.PolarToVec(0.455f, 300)}),
            new AppNodeInfo(10, new int[]{9}, new int[]{11}, new Vector3[]{AppUtil.PolarToVec(0.455f, 300), AppUtil.PolarToVec(0.455f, 310), AppUtil.PolarToVec(0.455f, 320), AppUtil.PolarToVec(0.455f, 330)}),
            new AppNodeInfo(11, new int[]{10}, new int[]{0}, new Vector3[]{AppUtil.PolarToVec(0.455f, 330), AppUtil.PolarToVec(0.455f, 340), AppUtil.PolarToVec(0.455f, 350), AppUtil.PolarToVec(0.455f, 0)}),
        }),
        //round 2
        new AppMapInfo(1, 12, 0.1f, new AppNodeInfo[]{
            new AppNodeInfo(0, new int[]{7}, new int[]{1}, new Vector3[]{AppUtil.PolarToVec(0.455f, 0), AppUtil.PolarToVec(0.455f, 15), AppUtil.PolarToVec(0.455f, 30), AppUtil.PolarToVec(0.455f, 45)}),
            new AppNodeInfo(1, new int[]{0}, new int[]{2}, new Vector3[]{AppUtil.PolarToVec(0.455f, 45), AppUtil.PolarToVec(0.455f, 60), AppUtil.PolarToVec(0.455f, 75), AppUtil.PolarToVec(0.455f, 90)}),
            new AppNodeInfo(2, new int[]{1}, new int[]{3}, new Vector3[]{AppUtil.PolarToVec(0.455f, 90), AppUtil.PolarToVec(0.455f, 105), AppUtil.PolarToVec(0.455f, 120), AppUtil.PolarToVec(0.455f, 135)}),
            new AppNodeInfo(3, new int[]{2}, new int[]{4}, new Vector3[]{AppUtil.PolarToVec(0.455f, 135), AppUtil.PolarToVec(0.455f, 150), AppUtil.PolarToVec(0.455f, 165), AppUtil.PolarToVec(0.455f, 180)}),
            new AppNodeInfo(4, new int[]{3}, new int[]{5}, new Vector3[]{AppUtil.PolarToVec(0.455f, 180), AppUtil.PolarToVec(0.455f, 195), AppUtil.PolarToVec(0.455f, 210), AppUtil.PolarToVec(0.455f, 225)}),
            new AppNodeInfo(5, new int[]{4}, new int[]{6}, new Vector3[]{AppUtil.PolarToVec(0.455f, 225), AppUtil.PolarToVec(0.455f, 240), AppUtil.PolarToVec(0.455f, 255), AppUtil.PolarToVec(0.455f, 270)}),
            new AppNodeInfo(6, new int[]{5}, new int[]{7}, new Vector3[]{AppUtil.PolarToVec(0.455f, 270), AppUtil.PolarToVec(0.455f, 285), AppUtil.PolarToVec(0.455f, 300), AppUtil.PolarToVec(0.455f, 315)}),
            new AppNodeInfo(7, new int[]{6}, new int[]{0}, new Vector3[]{AppUtil.PolarToVec(0.455f, 315), AppUtil.PolarToVec(0.455f, 330), AppUtil.PolarToVec(0.455f, 345), AppUtil.PolarToVec(0.455f, 0)}),
        }),
        //round 3
        new AppMapInfo(2, 12, 0.1f, new AppNodeInfo[]{
            new AppNodeInfo(0,  new int[]{7,  16, 18},  new int[]{1,  21, 23},  new Vector3[]{ AppUtil.PolarToVec(0.283f, 22.5f),  AppUtil.PolarToVec(0.283f, 37.5f),  AppUtil.PolarToVec(0.283f, 52.5f), AppUtil.PolarToVec(0.283f, 67.5f) }),
            new AppNodeInfo(1,  new int[]{0},           new int[]{2},           new Vector3[]{ AppUtil.PolarToVec(0.283f, 67.5f),  AppUtil.PolarToVec(0.283f, 82.5f),  AppUtil.PolarToVec(0.283f, 97.5f), AppUtil.PolarToVec(0.283f, 112.5f) }),
            new AppNodeInfo(2,  new int[]{1,  20, 22},  new int[]{3,  25, 27},  new Vector3[]{ AppUtil.PolarToVec(0.283f, 112.5f), AppUtil.PolarToVec(0.283f, 127.5f), AppUtil.PolarToVec(0.283f, 142.5f), AppUtil.PolarToVec(0.283f, 157.5f) }),
            new AppNodeInfo(3,  new int[]{2},           new int[]{4},           new Vector3[]{ AppUtil.PolarToVec(0.283f, 157.5f), AppUtil.PolarToVec(0.283f, 172.5f), AppUtil.PolarToVec(0.283f, 187.5f), AppUtil.PolarToVec(0.283f, 202.5f) }),
            new AppNodeInfo(4,  new int[]{3,  24, 26},  new int[]{5,  29, 31},  new Vector3[]{ AppUtil.PolarToVec(0.283f, 202.5f), AppUtil.PolarToVec(0.283f, 217.5f), AppUtil.PolarToVec(0.283f, 232.5f), AppUtil.PolarToVec(0.283f, 247.5f) }),
            new AppNodeInfo(5,  new int[]{4},           new int[]{6},           new Vector3[]{ AppUtil.PolarToVec(0.283f, 247.5f), AppUtil.PolarToVec(0.283f, 262.5f), AppUtil.PolarToVec(0.283f, 277.5f), AppUtil.PolarToVec(0.283f, 292.5f) }),
            new AppNodeInfo(6,  new int[]{5,  28, 30},  new int[]{7, 17, 19},   new Vector3[]{ AppUtil.PolarToVec(0.283f, 292.5f), AppUtil.PolarToVec(0.283f, 307.5f), AppUtil.PolarToVec(0.283f, 322.5f), AppUtil.PolarToVec(0.283f, 337.5f) }),
            new AppNodeInfo(7,  new int[]{6},           new int[]{0},           new Vector3[]{ AppUtil.PolarToVec(0.283f, 337.5f), AppUtil.PolarToVec(0.283f, 352.5f), AppUtil.PolarToVec(0.283f, 7.5f), AppUtil.PolarToVec(0.283f, 22.5f) }) ,
                                
            new AppNodeInfo(8,  new int[]{15, 16, 17},  new int[]{9,  22, 23},  new Vector3[]{ AppUtil.PolarToVec(0.455f, 22.5f),  AppUtil.PolarToVec(0.455f, 37.5f),  AppUtil.PolarToVec(0.455f, 52.5f), AppUtil.PolarToVec(0.455f, 67.5f) }),
            new AppNodeInfo(9,  new int[]{8},           new int[]{10},          new Vector3[]{ AppUtil.PolarToVec(0.455f, 67.5f),  AppUtil.PolarToVec(0.455f, 82.5f),  AppUtil.PolarToVec(0.455f, 97.5f), AppUtil.PolarToVec(0.455f, 112.5f) }),
            new AppNodeInfo(10, new int[]{9,  20, 21},  new int[]{11, 26, 27},  new Vector3[]{ AppUtil.PolarToVec(0.455f, 112.5f), AppUtil.PolarToVec(0.455f, 127.5f), AppUtil.PolarToVec(0.455f, 142.5f), AppUtil.PolarToVec(0.455f, 157.5f) }),
            new AppNodeInfo(11, new int[]{10},          new int[]{12},          new Vector3[]{ AppUtil.PolarToVec(0.455f, 157.5f), AppUtil.PolarToVec(0.455f, 172.5f), AppUtil.PolarToVec(0.455f, 187.5f), AppUtil.PolarToVec(0.455f, 202.5f) }),
            new AppNodeInfo(12, new int[]{11, 24, 25},  new int[]{13, 30, 31},  new Vector3[]{ AppUtil.PolarToVec(0.455f, 202.5f), AppUtil.PolarToVec(0.455f, 217.5f), AppUtil.PolarToVec(0.455f, 232.5f), AppUtil.PolarToVec(0.455f, 247.5f) }),
            new AppNodeInfo(13, new int[]{12},          new int[]{14},          new Vector3[]{ AppUtil.PolarToVec(0.455f, 247.5f), AppUtil.PolarToVec(0.455f, 262.5f), AppUtil.PolarToVec(0.455f, 277.5f), AppUtil.PolarToVec(0.455f, 292.5f) }),
            new AppNodeInfo(14, new int[]{13, 28, 29},  new int[]{15, 18, 19},  new Vector3[]{ AppUtil.PolarToVec(0.455f, 292.5f), AppUtil.PolarToVec(0.455f, 307.5f), AppUtil.PolarToVec(0.455f, 322.5f), AppUtil.PolarToVec(0.455f, 337.5f) }),
            new AppNodeInfo(15, new int[]{14},          new int[]{8},           new Vector3[]{ AppUtil.PolarToVec(0.455f, 337.5f), AppUtil.PolarToVec(0.455f, 352.5f), AppUtil.PolarToVec(0.455f, 7.5f), AppUtil.PolarToVec(0.455f, 22.5f) }) ,

            new AppNodeInfo(16, new int[]{0},  new int[]{8},  new Vector3[]{ AppUtil.PolarToVec(0.283f, 22.5f),   AppUtil.PolarToVec(0.263f, 0),    AppUtil.PolarToVec(0.400f, 0),    AppUtil.PolarToVec(0.455f, 22.5f) }),
            new AppNodeInfo(17, new int[]{6},  new int[]{8},  new Vector3[]{ AppUtil.PolarToVec(0.283f, -22.5f),  AppUtil.PolarToVec(0.263f, 0),    AppUtil.PolarToVec(0.400f, 0),    AppUtil.PolarToVec(0.455f, 22.5f) }),
            new AppNodeInfo(18, new int[]{0},  new int[]{14}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 22.5f),   AppUtil.PolarToVec(0.263f, 0),    AppUtil.PolarToVec(0.400f, 0),    AppUtil.PolarToVec(0.455f, -22.5f) }),
            new AppNodeInfo(19, new int[]{6},  new int[]{14}, new Vector3[]{ AppUtil.PolarToVec(0.283f, -22.5f),  AppUtil.PolarToVec(0.263f, 0),    AppUtil.PolarToVec(0.400f, 0),    AppUtil.PolarToVec(0.455f, -22.5f) }),
                                                                                                                                                                            
            new AppNodeInfo(20, new int[]{2},  new int[]{10}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 112.5f),  AppUtil.PolarToVec(0.263f, 90),   AppUtil.PolarToVec(0.400f, 90),   AppUtil.PolarToVec(0.455f, 112.5f) }),
            new AppNodeInfo(21, new int[]{0},  new int[]{10}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 67.5f),   AppUtil.PolarToVec(0.263f, 90),   AppUtil.PolarToVec(0.400f, 90),   AppUtil.PolarToVec(0.455f, 112.5f) }),
            new AppNodeInfo(22, new int[]{2},  new int[]{8 }, new Vector3[]{ AppUtil.PolarToVec(0.283f, 112.5f),  AppUtil.PolarToVec(0.263f, 90),   AppUtil.PolarToVec(0.400f, 90),   AppUtil.PolarToVec(0.455f, 67.5f) }),
            new AppNodeInfo(23, new int[]{0},  new int[]{8 }, new Vector3[]{ AppUtil.PolarToVec(0.283f, 67.5f),   AppUtil.PolarToVec(0.263f, 90),   AppUtil.PolarToVec(0.400f, 90),   AppUtil.PolarToVec(0.455f, 67.5f) }) ,
                                                                                                                                                                            
            new AppNodeInfo(24, new int[]{4},  new int[]{12}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 202.5f),  AppUtil.PolarToVec(0.263f, 180),  AppUtil.PolarToVec(0.400f, 180),  AppUtil.PolarToVec(0.455f, 202.5f) }),
            new AppNodeInfo(25, new int[]{2},  new int[]{12}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 157.5f),  AppUtil.PolarToVec(0.263f, 180),  AppUtil.PolarToVec(0.400f, 180),  AppUtil.PolarToVec(0.455f, 202.5f) }),
            new AppNodeInfo(26, new int[]{4},  new int[]{10}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 202.5f),  AppUtil.PolarToVec(0.263f, 180),  AppUtil.PolarToVec(0.400f, 180),  AppUtil.PolarToVec(0.455f, 157.5f) }),
            new AppNodeInfo(27, new int[]{2},  new int[]{10}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 157.5f),  AppUtil.PolarToVec(0.263f, 180),  AppUtil.PolarToVec(0.400f, 180),  AppUtil.PolarToVec(0.455f, 157.5f) }),
                                                                                                                                                                           
            new AppNodeInfo(28, new int[]{6},  new int[]{14}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 292.5f),  AppUtil.PolarToVec(0.263f, 270f), AppUtil.PolarToVec(0.400f, 270f), AppUtil.PolarToVec(0.455f, 292.5f) }),
            new AppNodeInfo(29, new int[]{4},  new int[]{14}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 247.5f),  AppUtil.PolarToVec(0.263f, 270f), AppUtil.PolarToVec(0.400f, 270f), AppUtil.PolarToVec(0.455f, 292.5f) }),
            new AppNodeInfo(30, new int[]{6},  new int[]{12}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 292.5f),  AppUtil.PolarToVec(0.263f, 270f), AppUtil.PolarToVec(0.400f, 270f), AppUtil.PolarToVec(0.455f, 257.5f) }),
            new AppNodeInfo(31, new int[]{4},  new int[]{12}, new Vector3[]{ AppUtil.PolarToVec(0.283f, 247.5f),  AppUtil.PolarToVec(0.263f, 270f), AppUtil.PolarToVec(0.400f, 270f), AppUtil.PolarToVec(0.455f, 257.5f) }) ,
        }),
        //round 4
        new AppMapInfo(3, 12, 0.1f, new AppNodeInfo[]{
            new AppNodeInfo(0,  new int[]{9},  new int[]{1},        new Vector3[]{ new Vector3(0, 0.28f, 0),    new Vector3(0.1f, 0.28f, 0), new Vector3(0.19f, 0.28f, 0),  new Vector3(0.29f, 0.28f, 0)}),

            new AppNodeInfo(1,  new int[]{0},  new int[]{2, 10},    new Vector3[]{ new Vector3(0.29f, 0.28f, 0),  new Vector3(0.37f, 0.28f, 0), new Vector3(0.45f, 0.21f, 0),  new Vector3(0.45f, 0.14f, 0)}),             
            new AppNodeInfo(2,  new int[]{1},  new int[]{3},        new Vector3[]{ new Vector3(0.45f, 0.14f, 0),  new Vector3(0.45f, 0.07f, 0), new Vector3(0.45f, -0.07f, 0), new Vector3(0.45f, -0.14f, 0)}),
            new AppNodeInfo(3,  new int[]{2, 11},  new int[]{4},    new Vector3[]{ new Vector3(0.29f, -0.28f, 0), new Vector3(0.37f, -0.28f, 0), new Vector3(0.45f, -0.21f, 0), new Vector3(0.45f, -0.14f, 0)}),
            new AppNodeInfo(4,  new int[]{3},  new int[]{5},        new Vector3[]{ new Vector3(0, -0.28f, 0), new Vector3(0.1f, -0.28f, 0), new Vector3(0.19f, -0.28f, 0), new Vector3(0.29f, -0.28f, 0)}),

            new AppNodeInfo(5,  new int[]{4},  new int[]{6},        new Vector3[]{ new Vector3(0f, -0.28f, 0), new Vector3(-0.1f, -0.28f, 0), new Vector3(-0.19f, -0.28f, 0), new Vector3(-0.29f, -0.28f, 0)}),
            new AppNodeInfo(6,  new int[]{5},  new int[]{7, 15},    new Vector3[]{ new Vector3(-0.29f, -0.28f, 0), new Vector3(-0.37f, -0.28f, 0), new Vector3(-0.45f, -0.21f, 0), new Vector3(-0.45f, -0.14f, 0)}),
            new AppNodeInfo(7,  new int[]{6},  new int[]{8},        new Vector3[]{ new Vector3(-0.45f, -0.14f, 0), new Vector3(-0.45f, -0.07f, 0), new Vector3(-0.45f, 0.07f, 0), new Vector3(-0.45f, 0.14f, 0)}),
            new AppNodeInfo(8,  new int[]{7, 14},  new int[]{9},    new Vector3[]{ new Vector3(-0.29f, 0.28f, 0), new Vector3(-0.37f, 0.28f, 0), new Vector3(-0.45f, 0.21f, 0), new Vector3(-0.45f, 0.14f, 0)}),
            new AppNodeInfo(9,  new int[]{8},  new int[]{0},       new Vector3[]{ new Vector3(0, 0.28f, 0), new Vector3(-0.1f, 0.28f, 0), new Vector3(-0.19f, 0.28f, 0), new Vector3(-0.29f, 0.28f, 0)}),

            new AppNodeInfo(10, new int[]{1},  new int[]{12},       new Vector3[]{ new Vector3(0.29f, 0, 0), new Vector3(0.37f, 0, 0), new Vector3(0.45f, 0.07f, 0), new Vector3(0.45f, 0.14f, 0)}),
            new AppNodeInfo(11, new int[]{3},  new int[]{12},       new Vector3[]{ new Vector3(0.29f, 0, 0), new Vector3(0.37f, 0, 0), new Vector3(0.45f, -0.07f, 0), new Vector3(0.45f, -0.14f, 0)}),

            new AppNodeInfo(12, new int[]{10, 11},  new int[]{13},  new Vector3[]{ new Vector3(0, 0, 0), new Vector3(0.1f, 0, 0), new Vector3(0.19f, 0, 0), new Vector3(0.29f, 0, 0)}),
            new AppNodeInfo(13, new int[]{12},  new int[]{14, 15},  new Vector3[]{ new Vector3(0, 0, 0), new Vector3(-0.1f, 0, 0), new Vector3(-0.19f, 0, 0), new Vector3(-0.29f, 0, 0)}),

            new AppNodeInfo(14, new int[]{8},  new int[]{13},       new Vector3[]{ new Vector3(-0.29f, 0, 0), new Vector3(-0.37f, 0, 0), new Vector3(-0.45f, 0.07f, 0), new Vector3(-0.45f, 0.14f, 0)}),
            new AppNodeInfo(15, new int[]{6},  new int[]{13},       new Vector3[]{ new Vector3(-0.29f, 0, 0), new Vector3(-0.37f, 0, 0), new Vector3(-0.45f, -0.07f, 0), new Vector3(-0.45f, -0.14f, 0) }),
        }),
        //round 5
        new AppMapInfo(4, 12, 0.1f, new AppNodeInfo[]{
        }),
    };
}
