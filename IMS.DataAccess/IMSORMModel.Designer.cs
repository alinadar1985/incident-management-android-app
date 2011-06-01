﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM-Beziehungsmetadaten

[assembly: EdmRelationshipAttribute("IMSORMModel", "OnSiteOperatorReport", "OnSiteOperator", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(IMS.DataAccess.OnSiteOperator), "Report", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(IMS.DataAccess.Report), true)]
[assembly: EdmRelationshipAttribute("IMSORMModel", "ReportPhoto", "Report", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(IMS.DataAccess.Report), "Photo", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(IMS.DataAccess.Photo), true)]

#endregion

namespace IMS.DataAccess
{
    #region Kontexte
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    public partial class IMSORMModelContainer : ObjectContext
    {
        #region Konstruktoren
    
        /// <summary>
        /// Initialisiert ein neues IMSORMModelContainer-Objekt mithilfe der in Abschnitt 'IMSORMModelContainer' der Anwendungskonfigurationsdatei gefundenen Verbindungszeichenfolge.
        /// </summary>
        public IMSORMModelContainer() : base("name=IMSORMModelContainer", "IMSORMModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues IMSORMModelContainer-Objekt.
        /// </summary>
        public IMSORMModelContainer(string connectionString) : base(connectionString, "IMSORMModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues IMSORMModelContainer-Objekt.
        /// </summary>
        public IMSORMModelContainer(EntityConnection connection) : base(connection, "IMSORMModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partielle Methoden
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet-Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<OnSiteOperator> OnSiteOperators
        {
            get
            {
                if ((_OnSiteOperators == null))
                {
                    _OnSiteOperators = base.CreateObjectSet<OnSiteOperator>("OnSiteOperators");
                }
                return _OnSiteOperators;
            }
        }
        private ObjectSet<OnSiteOperator> _OnSiteOperators;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Report> Reports
        {
            get
            {
                if ((_Reports == null))
                {
                    _Reports = base.CreateObjectSet<Report>("Reports");
                }
                return _Reports;
            }
        }
        private ObjectSet<Report> _Reports;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Photo> Photo
        {
            get
            {
                if ((_Photo == null))
                {
                    _Photo = base.CreateObjectSet<Photo>("Photo");
                }
                return _Photo;
            }
        }
        private ObjectSet<Photo> _Photo;

        #endregion
        #region AddTo-Methoden
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'OnSiteOperators'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToOnSiteOperators(OnSiteOperator onSiteOperator)
        {
            base.AddObject("OnSiteOperators", onSiteOperator);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Reports'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToReports(Report report)
        {
            base.AddObject("Reports", report);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Photo'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToPhoto(Photo photo)
        {
            base.AddObject("Photo", photo);
        }

        #endregion
    }
    

    #endregion
    
    #region Entitäten
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="IMSORMModel", Name="OnSiteOperator")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class OnSiteOperator : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues OnSiteOperator-Objekt.
        /// </summary>
        /// <param name="operatorID">Anfangswert der Eigenschaft OperatorID.</param>
        /// <param name="name">Anfangswert der Eigenschaft Name.</param>
        public static OnSiteOperator CreateOnSiteOperator(global::System.Guid operatorID, global::System.String name)
        {
            OnSiteOperator onSiteOperator = new OnSiteOperator();
            onSiteOperator.OperatorID = operatorID;
            onSiteOperator.Name = name;
            return onSiteOperator;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid OperatorID
        {
            get
            {
                return _OperatorID;
            }
            set
            {
                if (_OperatorID != value)
                {
                    OnOperatorIDChanging(value);
                    ReportPropertyChanging("OperatorID");
                    _OperatorID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("OperatorID");
                    OnOperatorIDChanged();
                }
            }
        }
        private global::System.Guid _OperatorID;
        partial void OnOperatorIDChanging(global::System.Guid value);
        partial void OnOperatorIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("IMSORMModel", "OnSiteOperatorReport", "Report")]
        public EntityCollection<Report> Reports
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Report>("IMSORMModel.OnSiteOperatorReport", "Report");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Report>("IMSORMModel.OnSiteOperatorReport", "Report", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="IMSORMModel", Name="Photo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Photo : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Photo-Objekt.
        /// </summary>
        /// <param name="contentMd5">Anfangswert der Eigenschaft ContentMd5.</param>
        /// <param name="reportID">Anfangswert der Eigenschaft ReportID.</param>
        public static Photo CreatePhoto(global::System.Guid contentMd5, global::System.Guid reportID)
        {
            Photo photo = new Photo();
            photo.ContentMd5 = contentMd5;
            photo.ReportID = reportID;
            return photo;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ContentMd5
        {
            get
            {
                return _ContentMd5;
            }
            set
            {
                if (_ContentMd5 != value)
                {
                    OnContentMd5Changing(value);
                    ReportPropertyChanging("ContentMd5");
                    _ContentMd5 = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ContentMd5");
                    OnContentMd5Changed();
                }
            }
        }
        private global::System.Guid _ContentMd5;
        partial void OnContentMd5Changing(global::System.Guid value);
        partial void OnContentMd5Changed();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ReportID
        {
            get
            {
                return _ReportID;
            }
            set
            {
                OnReportIDChanging(value);
                ReportPropertyChanging("ReportID");
                _ReportID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ReportID");
                OnReportIDChanged();
            }
        }
        private global::System.Guid _ReportID;
        partial void OnReportIDChanging(global::System.Guid value);
        partial void OnReportIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean UploadStatus
        {
            get
            {
                return _UploadStatus;
            }
            set
            {
                OnUploadStatusChanging(value);
                ReportPropertyChanging("UploadStatus");
                _UploadStatus = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UploadStatus");
                OnUploadStatusChanged();
            }
        }
        private global::System.Boolean _UploadStatus = false;
        partial void OnUploadStatusChanging(global::System.Boolean value);
        partial void OnUploadStatusChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("IMSORMModel", "ReportPhoto", "Report")]
        public Report Report
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Report>("IMSORMModel.ReportPhoto", "Report").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Report>("IMSORMModel.ReportPhoto", "Report").Value = value;
            }
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Report> ReportReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Report>("IMSORMModel.ReportPhoto", "Report");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Report>("IMSORMModel.ReportPhoto", "Report", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="IMSORMModel", Name="Report")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Report : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Report-Objekt.
        /// </summary>
        /// <param name="reportID">Anfangswert der Eigenschaft ReportID.</param>
        /// <param name="operatorID">Anfangswert der Eigenschaft OperatorID.</param>
        /// <param name="text">Anfangswert der Eigenschaft Text.</param>
        /// <param name="createDate">Anfangswert der Eigenschaft CreateDate.</param>
        /// <param name="location">Anfangswert der Eigenschaft Location.</param>
        /// <param name="receivedDate">Anfangswert der Eigenschaft ReceivedDate.</param>
        public static Report CreateReport(global::System.Guid reportID, global::System.Guid operatorID, global::System.String text, global::System.DateTime createDate, global::System.String location, global::System.DateTime receivedDate)
        {
            Report report = new Report();
            report.ReportID = reportID;
            report.OperatorID = operatorID;
            report.Text = text;
            report.CreateDate = createDate;
            report.Location = location;
            report.ReceivedDate = receivedDate;
            return report;
        }

        #endregion
        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid ReportID
        {
            get
            {
                return _ReportID;
            }
            set
            {
                if (_ReportID != value)
                {
                    OnReportIDChanging(value);
                    ReportPropertyChanging("ReportID");
                    _ReportID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ReportID");
                    OnReportIDChanged();
                }
            }
        }
        private global::System.Guid _ReportID;
        partial void OnReportIDChanging(global::System.Guid value);
        partial void OnReportIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid OperatorID
        {
            get
            {
                return _OperatorID;
            }
            set
            {
                OnOperatorIDChanging(value);
                ReportPropertyChanging("OperatorID");
                _OperatorID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OperatorID");
                OnOperatorIDChanged();
            }
        }
        private global::System.Guid _OperatorID;
        partial void OnOperatorIDChanging(global::System.Guid value);
        partial void OnOperatorIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                OnCreateDateChanging(value);
                ReportPropertyChanging("CreateDate");
                _CreateDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreateDate");
                OnCreateDateChanged();
            }
        }
        private global::System.DateTime _CreateDate;
        partial void OnCreateDateChanging(global::System.DateTime value);
        partial void OnCreateDateChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                OnPriorityChanging(value);
                ReportPropertyChanging("Priority");
                _Priority = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Priority");
                OnPriorityChanged();
            }
        }
        private global::System.String _Priority = "Medium";
        partial void OnPriorityChanging(global::System.String value);
        partial void OnPriorityChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Location
        {
            get
            {
                return _Location;
            }
            set
            {
                OnLocationChanging(value);
                ReportPropertyChanging("Location");
                _Location = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Location");
                OnLocationChanged();
            }
        }
        private global::System.String _Location;
        partial void OnLocationChanging(global::System.String value);
        partial void OnLocationChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime ReceivedDate
        {
            get
            {
                return _ReceivedDate;
            }
            set
            {
                OnReceivedDateChanging(value);
                ReportPropertyChanging("ReceivedDate");
                _ReceivedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ReceivedDate");
                OnReceivedDateChanged();
            }
        }
        private global::System.DateTime _ReceivedDate;
        partial void OnReceivedDateChanging(global::System.DateTime value);
        partial void OnReceivedDateChanged();

        #endregion
    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("IMSORMModel", "OnSiteOperatorReport", "OnSiteOperator")]
        public OnSiteOperator OnSiteOperator
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<OnSiteOperator>("IMSORMModel.OnSiteOperatorReport", "OnSiteOperator").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<OnSiteOperator>("IMSORMModel.OnSiteOperatorReport", "OnSiteOperator").Value = value;
            }
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<OnSiteOperator> OnSiteOperatorReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<OnSiteOperator>("IMSORMModel.OnSiteOperatorReport", "OnSiteOperator");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<OnSiteOperator>("IMSORMModel.OnSiteOperatorReport", "OnSiteOperator", value);
                }
            }
        }
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("IMSORMModel", "ReportPhoto", "Photo")]
        public EntityCollection<Photo> Photos
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Photo>("IMSORMModel.ReportPhoto", "Photo");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Photo>("IMSORMModel.ReportPhoto", "Photo", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
