# 课设，指纹器应用开发

运行方法:
        启动服务端开始监听。 (-/print/)             python hello runserver -h 0.0.0.0 -p 80         
        启动服务端，在生成的exe执行文件目录新建image目录用于保存录入指纹，录入同时会上传到服务端。
        
.
├── print                                               服务端，python flask开发，用于接受客户端上传的图片和显示。                                   
│   ├── data.sqlite                                     数据库 （实际未使用，觉得麻烦，没有必要）
│   ├── hello.py                                        主程序，代码比较少，没有分开写。
│   ├── migrations                                      数据库迁移模块 （无用）
│   │   ├── alembic.ini
│   │   ├── env.py
│   │   ├── README
│   │   ├── script.py.mako
│   │   └── versions
│   │       └── 38c4e85512a9_initial_migration.py
│   ├── static                                          静态文件存储目录（存储上传的指纹图片）
│   │   ├── 3153001.bmp                                 
│   │   ├── 3153002.bmp
│   │   ├── 3153003.bmp
│   │   ├── 3153004.bmp
│   │   ├── 3153005.bmp
│   │   ├── 3153006.bmp
│   │   └── favicon.ico
│   └── templates                                       静态页面
│       ├── 404.html
│       ├── 500.html
│       ├── base.html
│       ├── index.html
│       └── upload.html
└── Sample                                              客户端，基于已给demo的C#开发，添加post功能
    ├── BitmapFormat.cs                                 常用方法库，捕获，转换，对比，存储。 *新增的POSTfile函数在这里*
    ├── Form1.cs                                        图形端业务逻辑
    ├── Form1.Designer.cs                                        样式
    ├── Form1.resx                                      自动生成
    ├── Program.cs                                      程序入口
    ├── Properties                                      资源文件，不用看但是不能删
    │   ├── app.manifest
    │   ├── AssemblyInfo.cs
    │   ├── Resources.Designer.cs
    │   ├── Resources.resx
    │   ├── Settings.Designer.cs
    │   └── Settings.settings
    ├── Sample.csproj
    ├── Sample.csproj.sdsettings
    ├── Sample.csproj.user
    ├── Sample.OpenCover.Settings
    ├── Sample.sln
    ├── ZKFinger10.cs                                   指纹器算法库接口，提取模板，临时存储，对比
    └── ZKFPCap.cs                                      指纹器常用功能库，开关，捕获等

