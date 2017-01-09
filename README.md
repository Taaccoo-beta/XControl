# 温度控制系统

### 功能模块

- 升降温控制
- 温度拟合
- PID参数自检测

### 文件说明

Analog.cs  Counters.cs  Digital.cs  ErrorDef.cs  EventSupport.cs为官方提供代码，辅助MccDaq.dll库，提供MccDaq.dll以外的额外功能

MccDaq.dll 官方库，用于底层控制

DataSerialize.cs 序列化操作，用于保存参数设置

CoreControl.cs 废弃文件，暂不用

PortControl.cs 对官方库进行封装，使得操作底层端口更
加容易

GroupControl.cs 对PortControl.cs中的类进行封装，提供直接面向于八块设备的升降温操作

LeastSquareMethod.cs  包含最小二乘法的算法，用于温度拟合的参数计算

PIDControl.cs   包含PID控制算法，用于PID控制

MainForm.Designer.cs  程序界面设计代码，用于界面设计

MainForm.cs  软件核心控制模块，包含所有控制代码
