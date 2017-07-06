# Ray-Tracing-in-One-Weekend
An implementation of Ray-Tracing-in-One-Weekend using C#. (VS2017 c# winForm)<br>

Usage:<br>
1, Just goto the code in Form1.cs(line 25) like below:<br>

"this.bmp = Chapter.ch1(this.ClientRectangle.Width, this.ClientRectangle.Height);"<br>

And change the ch1 to ch? whatever chapter you want.<br>

2, run the project in VS2017 then you will see the result in form window.<br>

//////////////////////////////////////////////////////////////////////////<br>

关于chapter 11 景深的原理:<br>
在光线追踪中, lookFrom, lookAt, FOV(视角)决定了 画面看到的方向 以及 最终成像的张角(思考一下, 如果lookAt远离lookFrom的话, 则相同FOV会纳入更多景物).<br>
在此基础上, 添加了2个参数以实现景深: 焦距 和 光圈直径.<br>
光圈越小, 可以容纳的景深范围越大, 所以从远到近都是清楚的. 关于光圈可以搜索相关文章, 特别是关于摄影的.<br>
焦距决定了把多远距离的物体, 投影到的透视投影变换后的CVV平面上. <br>
如果某物体A不处在焦距的距离(比如更近), 则从光圈上随机选择一点后, 再向焦平面做射线的话, 该物体在这个点的原本颜色, 会被替换成新射线看到的颜色. 而光圈的大小, 就决定了这个物体的模糊半径, 光圈越大越模糊.<br>
