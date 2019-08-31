using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;


namespace MapControlApplication1
{
    class DataOperator
    {
        public IMap m_map;

        public DataOperator(IMap map)
        {
            m_map=map; 
        }
        //从地图对象中查找指定图层
        public ILayer GetLayerByName(string sLayerName) 
        { 
            //如果指定图层的名字或地图对象为空
            if(sLayerName==""||m_map==null)
            {
                return null;
            }
            //遍历查找与指定图层名字相同的图层
            //如果找到，返回该图层
            for (int i = 0; i < m_map.LayerCount; i++) 
            {
                if(m_map.get_Layer(i).Name==sLayerName)
                {
                    return m_map.get_Layer(i);
                }
            }
            //没有找到对应图层，返回NULL
            return null;
        }
        public DataTable GetContinentsName() {
            
            //获取图层Continents,通过IFeatureLayer接口来判断有没有获取成功
            //如果获取失败，返回NULL
            ILayer layer = GetLayerByName("Continents");
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            
            if (featureLayer == null) 
            {
                return null;
            }
            //利用IFeatureLayer接口的Search方法，得到要素指针接口对象，用于遍历图层中的全部要素
            //利用featureCursor.NextFeature();来获取要素
            //如果获取失败，返回NULL
            IFeature feature;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            feature = featureCursor.NextFeature();
            if (feature == null) 
            {
                return null;
            }
            //新建属性表
            DataTable dataTable = new DataTable();
            //新建数据列，用于保存各大洲的序号和名称
            //将数据列添加到数据表中
            DataColumn dataColumn=new DataColumn();
            dataColumn.ColumnName = "序号";
            dataColumn.DataType=System.Type.GetType("System.Int32");

            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.ColumnName = "名称";
            dataColumn.DataType = System.Type.GetType("System.String");

            dataTable.Columns.Add(dataColumn);

            //生成数据行DataRow
            //当要素不为空时，将要素在名称和序号字段上的值赋给DataRow的对应列中
            //在Continents图层中，序号信息在第0个字段，名称信息在第2个字段
            DataRow dataRow;
            while (feature != null) 
            {
                dataRow = dataTable.NewRow();
                dataRow[0] = feature.get_Value(0);
                dataRow[1] = feature.get_Value(2);
                dataTable.Rows.Add(dataRow);
                
                feature = featureCursor.NextFeature();
            }
            //属性表设置完成，返回属性表
            return dataTable;
        }
        public DataTable GetCitiesName(string srcLayer,string tagLayer,esriSpatialRelationEnum spatialRel)
        {

            //获取图层World Cities,通过IFeatureLayer接口来判断有没有获取成功
            //如果获取失败，返回NULL
            ILayer slayer = GetLayerByName(srcLayer);
            ILayer tlayer = GetLayerByName(tagLayer);
            IFeatureLayer sfeatureLayer = slayer as IFeatureLayer;
            IFeatureLayer tfeatureLayer = tlayer as IFeatureLayer;

            if (sfeatureLayer == null || tfeatureLayer == null)
            {
                return null;
            }
            //利用IFeatureLayer接口的Search方法，得到要素指针接口对象，用于遍历图层中的全部要素
            //利用featureCursor.NextFeature();来获取要素
            //如果获取失败，返回NULL
            //通过查询过滤从“Continents”图层获取“亚洲”这一几何图形
            IGeometry geometry;
            IFeature feature;
            IFeatureClass sfeatureClass;
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.WhereClause = "CONTINENT='Asia'";
            IFeatureCursor featureCursor = tfeatureLayer.FeatureClass.Search(queryFilter, false);
            feature = featureCursor.NextFeature();
            geometry = feature.Shape;
            if (feature == null)
            {
                return null;
            }

            //根据“亚洲”的几何图形来对城市图层进行属性和空间过滤
            ISpatialFilter spatialFilter = new SpatialFilter();
            sfeatureClass = sfeatureLayer.FeatureClass;
            spatialFilter.Geometry = geometry;
            spatialFilter.WhereClause = "POP_RANK=5";
            spatialFilter.SpatialRel = (ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum)spatialRel;

            IFeatureSelection selectfeature = (IFeatureSelection)sfeatureLayer;
            selectfeature.SelectFeatures(spatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            
            //用选中的要素生成一个新图层
            ISelectionSet selectionSet = selectfeature.SelectionSet;
            IFeatureLayer newLayer = null;
            if (selectionSet.Count > 0) {
                IFeatureLayerDefinition featureLayerDefinition = sfeatureLayer as IFeatureLayerDefinition;
                newLayer = featureLayerDefinition.CreateSelectionLayer(sfeatureClass.AliasName, true, null, null);
            }

            if (newLayer == null) {
                return null;
            }

            IFeature newFeature;
            IFeatureCursor newFeatureCursor = newLayer.Search(null, false);
            newFeature = newFeatureCursor.NextFeature();
            if (newFeature == null)
            {
                return null;
            }

            //新建属性表
            DataTable dataTable = new DataTable();
            //新建数据列，用于保存各大洲的序号和名称
            //将数据列添加到数据表中
            DataColumn dataColumn = new DataColumn();
            dataColumn.ColumnName = "序号";
            dataColumn.DataType = System.Type.GetType("System.Int32");

            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.ColumnName = "名称";
            dataColumn.DataType = System.Type.GetType("System.String");

            dataTable.Columns.Add(dataColumn);

            dataColumn=new DataColumn();
            dataColumn.ColumnName = "人口";
            dataColumn.DataType = System.Type.GetType("System.String");


            dataTable.Columns.Add(dataColumn);

            //生成数据行DataRow
            //当要素不为空时，将要素在名称和序号字段上的值赋给DataRow的对应列中
            //在Continents图层中，序号信息在第0个字段，名称信息在第2个字段
            DataRow dataRow;
            while (newFeature != null)
            {
                dataRow = dataTable.NewRow();
                dataRow[0] = newFeature.get_Value(0);
                dataRow[1] = newFeature.get_Value(2);
                dataRow[2] = newFeature.get_Value(9);
                dataTable.Rows.Add(dataRow);

                newFeature = newFeatureCursor.NextFeature();
            }

            //属性表设置完成，返回属性表
            return dataTable;
        }

        public DataTable Buffer(string layerName, string sWhere, int iSize, IMap iMap)
        {
            //根据过滤条件获取城市名称为北京的城市要素的几何
            IFeatureClass featureclass;
            IFeature feature;
            IGeometry geom;

            IFeatureLayer tFeatureLayer = (IFeatureLayer)GetLayerByName("Continents");
            IFeatureLayer featurelayer = (IFeatureLayer)GetLayerByName(layerName);

            featureclass = featurelayer.FeatureClass;
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.WhereClause = sWhere;//设置过滤条件

            IFeatureCursor featurecursor; 
            featurecursor = (IFeatureCursor)featureclass.Search(queryFilter, false);
            int count = featureclass.FeatureCount(queryFilter);

            feature = featurecursor.NextFeature();
            geom = feature.Shape;
            //根据缓冲区来设置空间查询的几何范围
            ITopologicalOperator topo = (ITopologicalOperator)geom;
            IGeometry buffer = topo.Buffer(iSize);
            //根据缓冲区几何对城市图层进行空间过滤
            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.Geometry = buffer;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIndexIntersects;

            IFeatureSelection featureSelect = (IFeatureSelection)featurelayer;
            featureSelect.SelectFeatures(spatialFilter,esriSelectionResultEnum.esriSelectionResultNew,false);
            //将第一次查询的结果生成一个新图层用于第二次查询
            IFeatureClass sFeatureClass = featurelayer.FeatureClass;
            ISelectionSet selectionSet = featureSelect.SelectionSet;
            IFeatureLayer newLayer = null;
            if (selectionSet.Count > 0)
            {
                IFeatureLayerDefinition featureLayerDefinition = featureSelect as IFeatureLayerDefinition;
                newLayer = featureLayerDefinition.CreateSelectionLayer(sFeatureClass.AliasName, true, null, null);
            }
            //我们得到了一个由符合"sWhere"条件的城市组成的新图层
            //现在用"亚洲"来进行属性和空间过滤
            IFeature feature2;
            IGeometry geom2;
            IQueryFilter queryFilter2 = new QueryFilter();
            queryFilter2.WhereClause = "CONTINENT='Asia'";
            IFeatureCursor featureCursor2 = tFeatureLayer.FeatureClass.Search(queryFilter2, false);
            feature2 = featureCursor2.NextFeature();
            geom2 = feature2.Shape;

            ISpatialFilter spatialFilter2 = new SpatialFilter();
            spatialFilter2.Geometry = geom2;
            spatialFilter2.SpatialRel = (ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum)esriSpatialRelationEnum.esriSpatialRelationIntersection;

            IFeatureSelection featureSelect2 = (IFeatureSelection)newLayer;
            featureSelect2.SelectFeatures(spatialFilter2, esriSelectionResultEnum.esriSelectionResultNew, false);
            //最后查询结果形成新图层用于数据展示
            IFeatureClass FeatureClass2 = newLayer.FeatureClass;
            ISelectionSet selectionSet2 = featureSelect2.SelectionSet;
            IFeatureLayer newLayer2 = null;
            if (selectionSet.Count > 0)
            {
                IFeatureLayerDefinition featureLayerDefinition = featureSelect2 as IFeatureLayerDefinition;
                newLayer2 = featureLayerDefinition.CreateSelectionLayer(FeatureClass2.AliasName, true, null, null);
            }
            //读取“选中的城市”图层中符合条件的要素
            IFeature newFeature;
            IFeatureCursor newFeatureCursor = newLayer2.Search(null, false);
            newFeature = newFeatureCursor.NextFeature();
            if (newFeature == null)
            {
                return null;
            }
            //创建属性表
            DataTable dataTable = new DataTable();

            DataColumn dataColumn = new DataColumn();
            dataColumn.ColumnName = "序号";
            dataColumn.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.ColumnName = "名称";
            dataColumn.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(dataColumn);

            DataRow dataRow;
            while (newFeature != null)
            {
                dataRow = dataTable.NewRow();
                dataRow[0] = newFeature.get_Value(0);
                dataRow[1] = newFeature.get_Value(2);
                dataTable.Rows.Add(dataRow);

                newFeature = newFeatureCursor.NextFeature();
            }
            return dataTable;
        }

        public static ISymbol GetSymbolByLayer(ILayer layer) {
            //判断图层是否获取成功
            if (layer == null) {
                return null;
            }

            //利用IFeatureLayer接口访问目标图层，获取图层的第一个要素
            //如果获取失败，返回空值
            IFeatureLayer featurelayer = layer as IFeatureLayer;
            IFeatureCursor featurecursor = featurelayer.Search(null, false);
            IFeature feature = featurecursor.NextFeature();
            if (feature == null) {
                return null;
            }
            //通过IGeoFeatureLayer访问图层，获取图层渲染器
            //如果获取失败，返回空值
            IGeoFeatureLayer geofeaturelayer = featurelayer as IGeoFeatureLayer;
            IFeatureRenderer featurerender = geofeaturelayer.Renderer;
            if (featurerender == null) {
                return null;
            }

            ISymbol symbol = featurerender.get_SymbolByFeature(feature);
           /* ISimpleLineSymbol spl = (ISimpleLineSymbol)symbol;
            spl.Style = esriSimpleLineStyle.esriSLSDash;
            symbol = (ISymbol)spl;*/
            return symbol;
        }

        public static bool SetSymbolColor(ILayer layer,IColor color) {
            //如果获取图层或者颜色失败，返回空值
            if (layer == null || color == null) {
                return false;
            }
            //获得指定图层的要素
            //如果获取失败，返回空值
            ISymbol symbol = GetSymbolByLayer(layer);
            
            if (symbol == null) {
                return false;
            }
            IFeatureLayer featurelayer = layer as IFeatureLayer;
            IFeatureClass featureclass = featurelayer.FeatureClass;
            if (featureclass == null) {
                return false;
            }
            //获取要素类的几何类型并设置颜色
            //如果几何形状不属于Point,Multipoint,Line,Polygon，则返回空值
            esriGeometryType geotype = featureclass.ShapeType;
            switch (geotype) {
                case esriGeometryType.esriGeometryPoint:
                    {
                        IMarkerSymbol markersymbol = symbol as IMarkerSymbol;
                        markersymbol.Color = color;
                        break;
                    }
                case esriGeometryType.esriGeometryMultipoint:
                    {
                        IMarkerSymbol markersymbol = symbol as IMarkerSymbol;
                        markersymbol.Color = color;
                        break;
                    }
                case esriGeometryType.esriGeometryLine:
                    {
                        ISimpleLineSymbol simplelinesymbol = symbol as ISimpleLineSymbol;
                        simplelinesymbol.Color = color;
                        break;
                    }
                case esriGeometryType.esriGeometryPolygon:
                    {
                        IFillSymbol fillsymbol = symbol as IFillSymbol;
                        fillsymbol.Color = color;
                        break;
                    }
                default:
                    return false;
            }
            //新建简单渲染器，用ISimpleRenderer来访问
            ISimpleRenderer simplerenderer = new SimpleRendererClass();
            simplerenderer.Symbol = symbol;
            
            /*ISimpleLineSymbol ss;
            IFeature p=featureclass.CreateFeature();
            ISimpleLineSymbol spl;
            esriDashAttributeType ds;
            
            spl.Style=esriSimpleLineStyle.esriSLSDash;
            ICartographicLineSymbol cl;
            cl.Cap=*/
            IFeatureRenderer featurerender = simplerenderer as IFeatureRenderer;
            if (featurerender == null) {
                return false;
            }
            //ISizeRenderer srender = simplerenderer as ISizeRenderer;
            //用IGeoFeatureLayer接口访问指定图层，并设置渲染器
            
            IGeoFeatureLayer geofeaturelayer = featurelayer as IGeoFeatureLayer;
            geofeaturelayer.Renderer = featurerender;
            return true;
        }
        
        public IFeatureClass CreateShapefile(string ParentDirectory,string sWorkspaceName,string FileName,string geotype) { 
            if(System.IO.Directory.Exists(ParentDirectory+sWorkspaceName)){
            System.IO.Directory.Delete(ParentDirectory+sWorkspaceName,true);
            }
            //创建针对shape文件的工作空间工场对象
            //通过参数创建相关工作空间（文件夹），用于包含shape文件
            IWorkspaceFactory WorkspaceFactory = new ShapefileWorkspaceFactoryClass();
            IWorkspaceName WorkspaceName = WorkspaceFactory.Create(ParentDirectory, sWorkspaceName, null, 0);
            ESRI.ArcGIS.esriSystem.IName name = WorkspaceName as ESRI.ArcGIS.esriSystem.IName;

            //打开新建的工作空间，并通过IFeatureWorkspace接口访问它
            IWorkspace workspace = (IWorkspace)name.Open();
            IFeatureWorkspace featureworkspace = workspace as IFeatureWorkspace;

            //创建、编辑shape文件的字段
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsedit = fields as IFieldsEdit;

            //创建并编辑“序号”字段
            //“序号”字段是要素类必备字段
            IFieldEdit fieldedit = new FieldClass();
            fieldedit.Name_2 = "OID";
            fieldedit.AliasName_2 = "序号";
            fieldedit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsedit.AddField((IField)fieldedit);
            
            //创建并编辑“名称”字段
            fieldedit = new FieldClass();
            fieldedit.Name_2 = "Name";
            fieldedit.AliasName_2 ="名称";
            fieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            fieldsedit.AddField((IField)fieldedit);

            IGeometryDefEdit geodefedit = new GeometryDefClass();
            ISpatialReference spatialreference = m_map.SpatialReference;
            geodefedit.SpatialReference_2 = spatialreference;
            //geotype这个字符串变量代表了要素类的几何类型
            switch (geotype)
            {
                case "Point":
                    geodefedit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                    break;
                case "Line":
                    geodefedit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
                    break;
                case "Polygon":
                    geodefedit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                    break;
                default:
                    geodefedit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                    break;
            }
            fieldedit = new FieldClass();
            //创建“形状”字段来表示要素类的集合类型
            string shapename="Shape";
            fieldedit.Name_2 = shapename;
            fieldedit.AliasName_2 = "形状";
            fieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;        
            fieldedit.GeometryDef_2 = geodefedit;
            fieldsedit.AddField((IField)fieldedit);

            IFeatureClass featureclass = featureworkspace.CreateFeatureClass(FileName, fields, null, null,
                esriFeatureType.esriFTSimple, "Shape", "");
            if (featureclass == null) {
                return null;
            }
            return featureclass;
        }

        public bool AddFeatureClassToMap(IFeatureClass featureclass, string layername) {
            if (featureclass == null || layername == null || m_map == null) {
                return false;
            }

            IFeatureLayer featurelayer = new FeatureLayerClass();
            featurelayer.FeatureClass = featureclass;
            featurelayer.Name = layername;

            ILayer layer = featurelayer as ILayer;
            if (layer == null) {
                return false;
            }
            //通过IMap的AddLayer函数来添加图层
            m_map.AddLayer(layer);
            IActiveView activeview = m_map as IActiveView;
            if (activeview == null) {
                return false;
            }
            activeview.Refresh();
            return true;
        }
        public bool AddFeatureToLayer(string LayerName, string FeatureName, IGeometry geometry) {
            if (LayerName == null || FeatureName == null || geometry == null || m_map == null) {
                return false;
            }
            ILayer layer = null;
            for (int i = 0; i < m_map.LayerCount; i++) {
                layer = m_map.get_Layer(i);
                if (layer.Name == LayerName) {
                    break;
                }
                layer = null;
            }

            //判断图层是否获取成功，若失败，函数返回false
            if (layer == null) {
                return false;
            }

            //通过IFeatureLayer接口访问获取到的图层
            IFeatureLayer featurelayer = layer as IFeatureLayer;
            IFeatureClass featureclass = featurelayer.FeatureClass;

            //
            IFeature feature = featureclass.CreateFeature();
            if (feature == null) {
                return false;
            }

            //if (geometry.GeometryType == esriGeometryType.esriGeometryPoint)
            //新建要素由geometry确定，对新建要素进行编辑，设置其坐标和属性值
            //保存该要素，并判断是否成功
            feature.Shape = geometry;
            int index = feature.Fields.FindField("Name");
            feature.set_Value(index, FeatureName);
            feature.Store();
            if (feature == null){
                return false;
            }

            //将地图对象转化为活动视图，并判断是否成功
            IActiveView activeview = m_map as IActiveView;
            if (activeview == null) {
                return false;
            }
            //刷新活动视图，新添加的要素将被展示在地图中
            //函数返回true
            activeview.Refresh();
            return true;
        }

        
    }
}
