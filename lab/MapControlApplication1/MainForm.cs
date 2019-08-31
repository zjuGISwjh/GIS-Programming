using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;

namespace MapControlApplication1
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }

        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {

        }

        private void axPageLayoutControl1_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            
        }
        public void CreateBookmark(string sBookmarkName) {
            IAOIBookmark aoiBookmark = new AOIBookmarkClass();

            //
            if (aoiBookmark != null) { 
            aoiBookmark.Location=axMapControl1.ActiveView.Extent;
            aoiBookmark.Name = sBookmarkName;
            }

            //add aoibookmark to map
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            if(bookmarks != null){
                bookmarks.AddBookmark(aoiBookmark);
            }
            //add aoibookmark to the comboxitem
            cbBookmarkList.Items.Add(aoiBookmark.Name);
        }

        private void miCreateBookmark_Click(object sender, EventArgs e)
        {
            AdmitBookmarkName frmABN = new AdmitBookmarkName(this);
            frmABN.Show();
        }

        private void cbBookmarkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get bookmark_list
            IMapBookmarks bookmarks = axMapControl1.Map as IMapBookmarks;
            IEnumSpatialBookmark enumSpatialBookmark = bookmarks.Bookmarks;

            //
            enumSpatialBookmark.Reset();
            ISpatialBookmark spatialBookmark = enumSpatialBookmark.Next();
            while (spatialBookmark != null) {
                if (cbBookmarkList.SelectedItem.ToString() == spatialBookmark.Name)
                {
                    spatialBookmark.ZoomTo((IMap)axMapControl1.ActiveView);
                    axMapControl1.ActiveView.Refresh();
                    break;
                }
                spatialBookmark = enumSpatialBookmark.Next();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DataBook_Click(object sender, EventArgs e)
        {

        }

        private void miAccessDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取保存有亚洲城市名的属性表，将其作为构造函数的参数
            //新建DataBook对象
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            DataBook dataBook = new DataBook("亚洲城市人口", 
            dataOperator.GetCitiesName("World Cities","Continents",esriSpatialRelationEnum.esriSpatialRelationIntersection));
            //在地图中显示选中的要素
            IActiveView activeview = axMapControl1.ActiveView;
            activeview.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, 0, axMapControl1.Extent);

            //展示DataBook对象
            dataBook.Show();
        }

        private void pageLayout_Click(object sender, EventArgs e)
        {
            //视图切换到打印视图
            //1.打印视图pageLayout菜单状态修改为checked
            //2.TOC Toolbar control 的Buddy control 修改为pagelayoutcontrol
            //3.Mapcontrol不可见，visible = false
            //  Pagelayoutcontrol可见，visible = true
            if (pageLayout.Checked == false)
            {
                axToolbarControl1.SetBuddyControl(axPageLayoutControl2.Object);
                axTOCControl1.SetBuddyControl(axPageLayoutControl2.Object);

                //axMapControl1.DocumentFilename
                //从mapcontrol获取地图文件名字并加载，实现pagelayout的地图随mapview的地图变化而变化
                axPageLayoutControl2.LoadMxFile(axMapControl1.DocumentFilename);
                axPageLayoutControl2.Show();
                axMapControl1.Hide();

                pageLayout.Checked = true;
                mapView.Checked = false;
                print.Enabled = true;
                MapOutPut.Enabled = print.Enabled;
            }
            else {//打开pagelayout页面后，再次单击pagelayout菜单项，又回到mapview页面
                axToolbarControl1.SetBuddyControl(axMapControl1.Object);
                axTOCControl1.SetBuddyControl(axMapControl1.Object);

                axPageLayoutControl2.Hide();
                axMapControl1.Show();

                pageLayout.Checked = false;
                mapView.Checked = true;
                print.Enabled = false;
                MapOutPut.Enabled = print.Enabled;
            }
        }

        private void mapView_Click(object sender, EventArgs e)
        {
            //视图切换到地图视图
            //1.地图视图mapView菜单状态修改为checked
            //2.TOC Toolbar control 的Buddy control 修改为pageLayoutcontrol
            //3.Mapcontrol可见，visible = true
            //  Pagelayoutcontrol不可见，visible = false
            if (mapView.Checked == false)
            {
                axToolbarControl1.SetBuddyControl(axMapControl1.Object);
                axTOCControl1.SetBuddyControl(axMapControl1.Object);

                axMapControl1.Show();
                axPageLayoutControl2.Hide();

                mapView.Checked = true;
                pageLayout.Checked = false;
                print.Enabled = false;
                MapOutPut.Enabled = print.Enabled;
            }
            else {
                axToolbarControl1.SetBuddyControl(axPageLayoutControl2.Object);
                axTOCControl1.SetBuddyControl(axPageLayoutControl2.Object);

                //从mapcontrol获取地图文件名字并加载，实现pagelayout的地图随mapview的地图变化而变化
                axPageLayoutControl2.LoadMxFile(axMapControl1.DocumentFilename);
                axMapControl1.Hide();
                axPageLayoutControl2.Show();

                mapView.Checked = false;
                pageLayout.Checked = true;
                print.Enabled = true;
                MapOutPut.Enabled = print.Enabled;
            }
        }

        private void miCartoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void simpleRenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取"World Cities"图层
            DataOperator dataoperator = new DataOperator(axMapControl1.Map);
            ILayer layer = dataoperator.GetLayerByName("World Cities");

            //通过IRgbColor接口新建rgbcolor对象，并设置颜色为蓝色
            IRgbColor rgbcolor = new RgbColorClass();
            rgbcolor.Red = 0;
            rgbcolor.Blue = 255;
            rgbcolor.Green = 0;

            //获取"World Cities"图层的要素信息，并通过IColor接口访问设置好的颜色对象
            ISymbol symbol = DataOperator.GetSymbolByLayer(layer);
            IColor color = rgbcolor as IColor;
            //判断图层和颜色是否获取成功，如果获取成功，则当前视图刷新，并显示简单渲染效果
            //使simplerender菜单项不可再用
            //如果获取失败，则弹出消息框提示"简单渲染失败!"
            bool t = DataOperator.SetSymbolColor(layer, color);
            if (t)
            {
                axTOCControl1.ActiveView.ContentsChanged();
                axMapControl1.ActiveView.Refresh();
                simpleRender.Enabled = false;
            }
            else {
                MessageBox.Show("简单渲染失败!");
            }
        }

        private void axPageLayoutControl2_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {

        }

        private void output_Click(object sender, EventArgs e)
        {
            //通过IPrinter接口获取默认打印机
            //如果获取失败，消息框提示"Can not get the default printer!"
            IPrinter printer = axPageLayoutControl1.Printer;
            if (printer == null) {
                MessageBox.Show("Can not get the default printer!");
            }
            //消息框提示是否使用默认打印机
            //若点击Cancel，则退出打印
            string mess = "Use the default printer" + printer.Name + "?";
            if (MessageBox.Show(mess, "", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
                return;
            }
            //通过IPaper接口访问打印机的纸张，用paper.Orientation设置方向为纵向
            IPaper paper = printer.Paper;
            paper.Orientation = 1;

            //打印的对象尺寸可以用PutCustomSize来调节
            //通过IPage接口设置打印分页为缩小到一页
            IPage page = axPageLayoutControl1.Page;
            //page.PutCustomSize(29.7, 21.0);
            page.PageToPrinterMapping = esriPageToPrinterMapping.esriPageMappingScale;

            axPageLayoutControl1.PrintPageLayout(1, 1, 0);
        }

        private void mapOutPutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IActiveView docActiveView;
            IExport docExport;
            IPrintAndExport docPrintExport;
            //设置图片分辨率，下方注释掉的代码为根据监听当前窗口的分辨率来设置分辨率
            //经测试发现将分辨率直接设置为300的情况下导出地图更清晰
            int iOutputResolution = 300;
            //double iOutputResolution = axMapControl1.ActiveView.ScreenDisplay.DisplayTransformation.Resolution;

            if (pageLayout.Checked == true)//输出pagelayout
            {
                docActiveView = axMapControl1.ActiveView;
            }
            else {//输出mapview
                docActiveView = axPageLayoutControl2.ActiveView;
            }
           // docExport = new ExportJPEGClass();
            //docPrintExport = new PrintAndExportClass();

            //设置输出的文件名
            //选择保存格式，可以保存为jpg,png和pdf
            SaveFileDialog savefiledialog1 = new SaveFileDialog();
            savefiledialog1.DefaultExt = ".jpg";
            savefiledialog1.Filter = "JPG Documents (*.jpg)|*.jpg|PDF Documents(*.pdf)|*.pdf|PNG Documents(*.png)|*.png";
            savefiledialog1.ShowDialog();
            docExport = new ExportJPEGClass();
            //设置保存的文件名
            string Outpath = savefiledialog1.FileName;
            //得到输出文件的扩展名
            string fileExtName = Outpath.Substring(Outpath.LastIndexOf(".") + 1).ToString();
            if (fileExtName != "")
            {
                switch(fileExtName){
                    case "jpg":
                        docExport = new ExportJPEGClass();
                        break;
                    case "pdf":
                        docExport = new ExportPDFClass();
                        break;
                    case "png":
                        docExport = new ExportPNGClass();
                        break;
                    default:
                        MessageBox.Show("只能保存为: jpg,pdf,png 格式");
                        break;   
                }
            }
            docPrintExport = new PrintAndExportClass();
            docExport.ExportFileName = Outpath;
        

          
            //输出当前视图到输出文件
            docPrintExport.Export(docActiveView, docExport, iOutputResolution, true, null);
        }

        private void miCreateShapefile_Click(object sender, EventArgs e)
        {
           
        }

        private void miAddFeature_Click(object sender, EventArgs e)
        {
            
        }

        INewLineFeedback m_NewLineFeedback = new NewLineFeedbackClass();

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //当"添加要素"菜单项被勾选时，进行如下操作
            if (AddPoint.Checked == true) {
                IPoint point = new PointClass();
                point.PutCoords(e.mapX, e.mapY);

                DataOperator dataOperator = new DataOperator(axMapControl1.Map);
                dataOperator.AddFeatureToLayer("Observation Stations", "观测站", point);
                return;
            }
            //以下使用的是trackline和trackpolygon函数来进行线和多边形的绘制
            //注释的代码部分为另一种绘制线的方式
            if (AddLine.Checked == true) {
                /*ISimpleLineSymbol SimpleLineSymbol = new SimpleLineSymbolClass();
                SimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDot;
                IRgbColor rgbColor = new RgbColorClass();
                rgbColor.Red = 255;
                SimpleLineSymbol.Color = rgbColor;
                SimpleLineSymbol.Width = 3;
                object o = (object)SimpleLineSymbol;
                IGeometry Geometry;
                Geometry = axMapControl1.TrackLine();
                axMapControl1.DrawShape(Geometry, ref o);*/

                IGeometry polyline = axMapControl1.TrackLine();
                ILineElement LineElement;
                LineElement = new LineElementClass();
                IElement Element = LineElement as IElement;
                Element.Geometry = polyline;

                IGraphicsContainer GraphicsContainer = axMapControl1.Map as IGraphicsContainer;
                GraphicsContainer.AddElement((IElement)LineElement, 0);

                axMapControl1.ActiveView.Refresh();
            }
            if (AddPolygon.Checked == true) {
                IGeometry Polygon = axMapControl1.TrackPolygon();
                IPolygonElement PolygonElement = new PolygonElementClass();
                IElement Element = PolygonElement as IElement;
                Element.Geometry = Polygon;
                IGraphicsContainer GraphicsContainer = axMapControl1.Map as IGraphicsContainer;
                GraphicsContainer.AddElement((IElement)PolygonElement, 0);
                axMapControl1.ActiveView.Refresh();
            }
        }


        private void pointshp_Click(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            /*CreateFeatureclass createfeatureclass = new CreateFeatureclass(this);
            createfeatureclass.Show();*/
            IFeatureClass featureClass = dataOperator.CreateShapefile("E:\\", "ShapefileWorespace", "ShapefileSample","Point");
            if (featureClass == null)
            {
                MessageBox.Show("创建shapefile文件失败！");
                return;
            }
            //将要素类添加到地图中，图层名为"Observation Stations"
            //如果创建成功，将"创建shapefile"按钮禁用
            //如果创建失败，弹出消息框提示
            bool bRes = dataOperator.AddFeatureClassToMap(featureClass, "Observation Stations");
            if (bRes)
            {
                pointshp.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("将新建shapefile文件加入地图失败！");
                return;
            }
        }

        private void AddPoint_Click(object sender, EventArgs e)
        {
            if (AddPoint.Checked == false)
            {
                AddPoint.Checked = true;
            }
            else
            {
                AddPoint.Checked = false;
            }
        }
        //DataBook newdatabook = new DataBook();
        private void lineshp_Click(object sender, EventArgs e)
        {
            
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            IFeatureClass featureClass = dataOperator.CreateShapefile("E:\\", "ShapefileWorespace", "ShapefileSample", "Line");
            if (featureClass == null)
            {
                MessageBox.Show("创建shapefile文件失败！");
                return;
            }
            //将要素类添加到地图中，图层名为"Observation Stations"
            //如果创建成功，将"创建shapefile"按钮禁用
            //如果创建失败，弹出消息框提示
            bool bRes = dataOperator.AddFeatureClassToMap(featureClass, "Observation Stations");
            if (bRes)
            {
                lineshp.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("将新建shapefile文件加入地图失败！");
                return;
            }
        }

        private void polyshp_Click(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            IFeatureClass featureClass = dataOperator.CreateShapefile("E:\\", "ShapefileWorespace", "ShapefileSample", "Polygon");
            if (featureClass == null)
            {
                MessageBox.Show("创建shapefile文件失败！");
                return;
            }
            //将要素类添加到地图中，图层名为"Observation Stations"
            //如果创建成功，将"创建shapefile"按钮禁用
            //如果创建失败，弹出消息框提示
            bool bRes = dataOperator.AddFeatureClassToMap(featureClass, "Observation Stations");
            if (bRes)
            {
                polyshp.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("将新建shapefile文件加入地图失败！");
                return;
            }
        }

        private void AddLine_Click(object sender, EventArgs e)
        {
            if (AddLine.Checked == false)
            {
                AddLine.Checked = true;
            }
            else
            {
                AddLine.Checked = false;
            }
        }

        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
                

        }

        private void AddPolygon_Click(object sender, EventArgs e)
        {
            if (AddPolygon.Checked == false)
            {
                AddPolygon.Checked = true;
            }
            else
            {
                AddPolygon.Checked = false;
            }
        }
         
        private void myBuffer_Click(object sender, EventArgs e)
        {
            DataOperator dataOperator = new DataOperator(axMapControl1.Map);
            //dataOperator.Buffer("World Cities","CITY_NAME='Istanbul'",1,axMapControl1.Map);
            int col;
            Form form2 = new BufferAnalysis();
            //form2.Show();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                string str = form2.Controls["textBox1"].Text;
                col = int.Parse(str);
                DataBook databook = new DataBook("Istanbul's Cities", dataOperator.Buffer("World Cities", "CITY_NAME='Istanbul'", col, axMapControl1.Map));
                //在地图中显示选中的要素
                IActiveView activeview = axMapControl1.ActiveView;
                activeview.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, 0, axMapControl1.Extent);
                databook.Show();
            }
        }
    }
}