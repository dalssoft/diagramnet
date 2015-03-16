using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Dalssoft.DiagramNet;

namespace Dalssoft.TestForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private bool changeDocumentProp = true;

		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton btnSize;
		private System.Windows.Forms.ToolBarButton btnAdd;
		private System.Windows.Forms.ToolBarButton btnDelete;
		private System.Windows.Forms.ToolBarButton btnConnect;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.ToolBarButton sep1;
		private System.Windows.Forms.ToolBarButton btnSave;
		private System.Windows.Forms.ToolBarButton btnOpen;
		private System.Windows.Forms.ToolBarButton sep2;
		private System.Windows.Forms.ToolBarButton btnUndo;
		private System.Windows.Forms.ToolBarButton btnRedo;
		private System.Windows.Forms.ToolBarButton sep3;
		private System.Windows.Forms.ToolBarButton btnFront;
		private System.Windows.Forms.ToolBarButton btnBack;
		private System.Windows.Forms.ToolBarButton btnMoveUp;
		private System.Windows.Forms.ToolBarButton btnMoveDown;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuOpen;
		private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuRedo;
		private System.Windows.Forms.MenuItem mnuAdd;
		private System.Windows.Forms.MenuItem mnuRectangle;
		private System.Windows.Forms.MenuItem mnuElipse;
		private System.Windows.Forms.MenuItem mnuRectangleNode;
		private System.Windows.Forms.MenuItem mnuElipseNode;
		private System.Windows.Forms.MenuItem mnuDelete;
		private System.Windows.Forms.MenuItem mnuConnect;
		private System.Windows.Forms.MenuItem mnuOrder;
		private System.Windows.Forms.MenuItem mnuBringToFront;
		private System.Windows.Forms.MenuItem mnuSendToBack;
		private System.Windows.Forms.MenuItem mnuMoveUp;
		private System.Windows.Forms.MenuItem mnuMoveDown;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.MenuItem mnuSize;
		private System.Windows.Forms.MenuItem mnuTbRectangle;
		private System.Windows.Forms.MenuItem mnuTbElipse;
		private System.Windows.Forms.MenuItem mnuTbRectangleNode;
		private System.Windows.Forms.MenuItem mnuTbElipseNode;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.MenuItem mnuUndo;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem mnuTbStraightLink;
		private System.Windows.Forms.MenuItem mnuTbRightAngleLink;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuCut;
		private System.Windows.Forms.MenuItem mnuPaste;
		private System.Windows.Forms.MenuItem mnuCopy;
		private System.Windows.Forms.ToolBarButton sep4;
		private System.Windows.Forms.ToolBarButton btnCut;
		private System.Windows.Forms.ToolBarButton btnCopy;
		private System.Windows.Forms.ToolBarButton btnPaste;
		private System.Windows.Forms.ToolBarButton sep5;
		private System.Windows.Forms.ToolBarButton btnZoom;
		private System.Windows.Forms.ContextMenu contextMenu_Zoom;
		private System.Windows.Forms.MenuItem mnuZoom_10;
		private System.Windows.Forms.MenuItem mnuZoom_25;
		private System.Windows.Forms.MenuItem mnuZoom_50;
		private System.Windows.Forms.MenuItem mnuZoom_75;
		private System.Windows.Forms.MenuItem mnuZoom_100;
		private System.Windows.Forms.MenuItem mnuZoom_150;
		private System.Windows.Forms.MenuItem mnuZoom_200;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.MenuItem mnuShowDebugLog;
		private System.Windows.Forms.MenuItem menuItem1;
		private Dalssoft.DiagramNet.Designer designer1;
		private System.Windows.Forms.MenuItem TbCommentBox;
		private System.ComponentModel.IContainer components;

		public Form1()
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.btnOpen = new System.Windows.Forms.ToolBarButton();
			this.btnSave = new System.Windows.Forms.ToolBarButton();
			this.sep1 = new System.Windows.Forms.ToolBarButton();
			this.btnCut = new System.Windows.Forms.ToolBarButton();
			this.btnCopy = new System.Windows.Forms.ToolBarButton();
			this.btnPaste = new System.Windows.Forms.ToolBarButton();
			this.btnDelete = new System.Windows.Forms.ToolBarButton();
			this.sep4 = new System.Windows.Forms.ToolBarButton();
			this.btnSize = new System.Windows.Forms.ToolBarButton();
			this.btnAdd = new System.Windows.Forms.ToolBarButton();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuTbRectangle = new System.Windows.Forms.MenuItem();
			this.mnuTbElipse = new System.Windows.Forms.MenuItem();
			this.mnuTbRectangleNode = new System.Windows.Forms.MenuItem();
			this.mnuTbElipseNode = new System.Windows.Forms.MenuItem();
			this.TbCommentBox = new System.Windows.Forms.MenuItem();
			this.btnConnect = new System.Windows.Forms.ToolBarButton();
			this.contextMenu2 = new System.Windows.Forms.ContextMenu();
			this.mnuTbStraightLink = new System.Windows.Forms.MenuItem();
			this.mnuTbRightAngleLink = new System.Windows.Forms.MenuItem();
			this.sep2 = new System.Windows.Forms.ToolBarButton();
			this.btnUndo = new System.Windows.Forms.ToolBarButton();
			this.btnRedo = new System.Windows.Forms.ToolBarButton();
			this.sep3 = new System.Windows.Forms.ToolBarButton();
			this.btnZoom = new System.Windows.Forms.ToolBarButton();
			this.contextMenu_Zoom = new System.Windows.Forms.ContextMenu();
			this.mnuZoom_10 = new System.Windows.Forms.MenuItem();
			this.mnuZoom_25 = new System.Windows.Forms.MenuItem();
			this.mnuZoom_50 = new System.Windows.Forms.MenuItem();
			this.mnuZoom_75 = new System.Windows.Forms.MenuItem();
			this.mnuZoom_100 = new System.Windows.Forms.MenuItem();
			this.mnuZoom_150 = new System.Windows.Forms.MenuItem();
			this.mnuZoom_200 = new System.Windows.Forms.MenuItem();
			this.sep5 = new System.Windows.Forms.ToolBarButton();
			this.btnFront = new System.Windows.Forms.ToolBarButton();
			this.btnBack = new System.Windows.Forms.ToolBarButton();
			this.btnMoveUp = new System.Windows.Forms.ToolBarButton();
			this.btnMoveDown = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuOpen = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuUndo = new System.Windows.Forms.MenuItem();
			this.mnuRedo = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuCut = new System.Windows.Forms.MenuItem();
			this.mnuCopy = new System.Windows.Forms.MenuItem();
			this.mnuPaste = new System.Windows.Forms.MenuItem();
			this.mnuDelete = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.mnuSize = new System.Windows.Forms.MenuItem();
			this.mnuAdd = new System.Windows.Forms.MenuItem();
			this.mnuRectangle = new System.Windows.Forms.MenuItem();
			this.mnuElipse = new System.Windows.Forms.MenuItem();
			this.mnuRectangleNode = new System.Windows.Forms.MenuItem();
			this.mnuElipseNode = new System.Windows.Forms.MenuItem();
			this.mnuConnect = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.mnuOrder = new System.Windows.Forms.MenuItem();
			this.mnuBringToFront = new System.Windows.Forms.MenuItem();
			this.mnuSendToBack = new System.Windows.Forms.MenuItem();
			this.mnuMoveUp = new System.Windows.Forms.MenuItem();
			this.mnuMoveDown = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuShowDebugLog = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.designer1 = new Dalssoft.DiagramNet.Designer();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.AllowDrop = true;
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.btnOpen,
																						this.btnSave,
																						this.sep1,
																						this.btnCut,
																						this.btnCopy,
																						this.btnPaste,
																						this.btnDelete,
																						this.sep4,
																						this.btnSize,
																						this.btnAdd,
																						this.btnConnect,
																						this.sep2,
																						this.btnUndo,
																						this.btnRedo,
																						this.sep3,
																						this.btnZoom,
																						this.sep5,
																						this.btnFront,
																						this.btnBack,
																						this.btnMoveUp,
																						this.btnMoveDown});
			this.toolBar1.Divider = false;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(696, 26);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.Wrappable = false;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// btnOpen
			// 
			this.btnOpen.ImageIndex = 6;
			this.btnOpen.Tag = "Open";
			this.btnOpen.ToolTipText = "Open";
			// 
			// btnSave
			// 
			this.btnSave.ImageIndex = 5;
			this.btnSave.Tag = "Save";
			this.btnSave.ToolTipText = "Save";
			// 
			// sep1
			// 
			this.sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnCut
			// 
			this.btnCut.ImageIndex = 13;
			this.btnCut.Tag = "Cut";
			this.btnCut.ToolTipText = "Cut";
			// 
			// btnCopy
			// 
			this.btnCopy.ImageIndex = 14;
			this.btnCopy.Tag = "Copy";
			this.btnCopy.ToolTipText = "Copy";
			// 
			// btnPaste
			// 
			this.btnPaste.ImageIndex = 15;
			this.btnPaste.Tag = "Paste";
			this.btnPaste.ToolTipText = "Paste";
			// 
			// btnDelete
			// 
			this.btnDelete.ImageIndex = 2;
			this.btnDelete.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.btnDelete.Tag = "Delete";
			this.btnDelete.ToolTipText = "Delete";
			// 
			// sep4
			// 
			this.sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnSize
			// 
			this.btnSize.ImageIndex = 0;
			this.btnSize.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.btnSize.Tag = "Size";
			this.btnSize.ToolTipText = "Size";
			// 
			// btnAdd
			// 
			this.btnAdd.DropDownMenu = this.contextMenu1;
			this.btnAdd.ImageIndex = 1;
			this.btnAdd.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.btnAdd.Tag = "Add";
			this.btnAdd.ToolTipText = "Add";
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuTbRectangle,
																						 this.mnuTbElipse,
																						 this.mnuTbRectangleNode,
																						 this.mnuTbElipseNode,
																						 this.TbCommentBox});
			// 
			// mnuTbRectangle
			// 
			this.mnuTbRectangle.Index = 0;
			this.mnuTbRectangle.Text = "&Rectangle";
			this.mnuTbRectangle.Click += new System.EventHandler(this.mnuTbRectangle_Click);
			// 
			// mnuTbElipse
			// 
			this.mnuTbElipse.Index = 1;
			this.mnuTbElipse.Text = "&Elipse";
			this.mnuTbElipse.Click += new System.EventHandler(this.mnuTbElipse_Click);
			// 
			// mnuTbRectangleNode
			// 
			this.mnuTbRectangleNode.Index = 2;
			this.mnuTbRectangleNode.Text = "&Node Rectangle";
			this.mnuTbRectangleNode.Click += new System.EventHandler(this.mnuTbRectangleNode_Click);
			// 
			// mnuTbElipseNode
			// 
			this.mnuTbElipseNode.Index = 3;
			this.mnuTbElipseNode.Text = "N&ode Elipse";
			this.mnuTbElipseNode.Click += new System.EventHandler(this.mnuTbElipseNode_Click);
			// 
			// TbCommentBox
			// 
			this.TbCommentBox.Index = 4;
			this.TbCommentBox.Text = "Comment Box";
			this.TbCommentBox.Click += new System.EventHandler(this.TbCommentBox_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.DropDownMenu = this.contextMenu2;
			this.btnConnect.ImageIndex = 3;
			this.btnConnect.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.btnConnect.Tag = "Connect";
			this.btnConnect.ToolTipText = "Connect";
			// 
			// contextMenu2
			// 
			this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuTbStraightLink,
																						 this.mnuTbRightAngleLink});
			// 
			// mnuTbStraightLink
			// 
			this.mnuTbStraightLink.Index = 0;
			this.mnuTbStraightLink.Text = "Straight Link";
			this.mnuTbStraightLink.Click += new System.EventHandler(this.mnuTbStraightLink_Click);
			// 
			// mnuTbRightAngleLink
			// 
			this.mnuTbRightAngleLink.Index = 1;
			this.mnuTbRightAngleLink.Text = "Right Angle Link";
			this.mnuTbRightAngleLink.Click += new System.EventHandler(this.mnuTbRightAngleLink_Click);
			// 
			// sep2
			// 
			this.sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnUndo
			// 
			this.btnUndo.ImageIndex = 7;
			this.btnUndo.Tag = "Undo";
			this.btnUndo.ToolTipText = "Undo";
			// 
			// btnRedo
			// 
			this.btnRedo.ImageIndex = 8;
			this.btnRedo.Tag = "Redo";
			this.btnRedo.ToolTipText = "Redo";
			// 
			// sep3
			// 
			this.sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnZoom
			// 
			this.btnZoom.DropDownMenu = this.contextMenu_Zoom;
			this.btnZoom.ImageIndex = 16;
			this.btnZoom.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.btnZoom.Tag = "Zoom";
			// 
			// contextMenu_Zoom
			// 
			this.contextMenu_Zoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.mnuZoom_10,
																							 this.mnuZoom_25,
																							 this.mnuZoom_50,
																							 this.mnuZoom_75,
																							 this.mnuZoom_100,
																							 this.mnuZoom_150,
																							 this.mnuZoom_200});
			// 
			// mnuZoom_10
			// 
			this.mnuZoom_10.Index = 0;
			this.mnuZoom_10.Text = "10%";
			this.mnuZoom_10.Click += new System.EventHandler(this.mnuZoom_10_Click);
			// 
			// mnuZoom_25
			// 
			this.mnuZoom_25.Index = 1;
			this.mnuZoom_25.Text = "25%";
			this.mnuZoom_25.Click += new System.EventHandler(this.mnuZoom_25_Click);
			// 
			// mnuZoom_50
			// 
			this.mnuZoom_50.Index = 2;
			this.mnuZoom_50.Text = "50%";
			this.mnuZoom_50.Click += new System.EventHandler(this.mnuZoom_50_Click);
			// 
			// mnuZoom_75
			// 
			this.mnuZoom_75.Index = 3;
			this.mnuZoom_75.Text = "75%";
			this.mnuZoom_75.Click += new System.EventHandler(this.mnuZoom_75_Click);
			// 
			// mnuZoom_100
			// 
			this.mnuZoom_100.Index = 4;
			this.mnuZoom_100.Text = "100%";
			this.mnuZoom_100.Click += new System.EventHandler(this.mnuZoom_100_Click);
			// 
			// mnuZoom_150
			// 
			this.mnuZoom_150.Index = 5;
			this.mnuZoom_150.Text = "150%";
			this.mnuZoom_150.Click += new System.EventHandler(this.mnuZoom_150_Click);
			// 
			// mnuZoom_200
			// 
			this.mnuZoom_200.Index = 6;
			this.mnuZoom_200.Text = "200%";
			this.mnuZoom_200.Click += new System.EventHandler(this.mnuZoom_200_Click);
			// 
			// sep5
			// 
			this.sep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnFront
			// 
			this.btnFront.ImageIndex = 9;
			this.btnFront.Tag = "Front";
			this.btnFront.ToolTipText = "Bring to Front";
			// 
			// btnBack
			// 
			this.btnBack.ImageIndex = 10;
			this.btnBack.Tag = "Back";
			this.btnBack.ToolTipText = "Send to Back";
			// 
			// btnMoveUp
			// 
			this.btnMoveUp.ImageIndex = 11;
			this.btnMoveUp.Tag = "MoveUp";
			this.btnMoveUp.ToolTipText = "Move Up";
			// 
			// btnMoveDown
			// 
			this.btnMoveDown.ImageIndex = 12;
			this.btnMoveDown.Tag = "MoveDown";
			this.btnMoveDown.ToolTipText = "Move Down";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Silver;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuFile,
																					  this.mnuEdit,
																					  this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuOpen,
																					this.mnuSave,
																					this.menuItem26,
																					this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Index = 0;
			this.mnuOpen.Text = "&Open";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// mnuSave
			// 
			this.mnuSave.Index = 1;
			this.mnuSave.Text = "&Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 2;
			this.menuItem26.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 3;
			this.mnuExit.Text = "&Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 1;
			this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuUndo,
																					this.mnuRedo,
																					this.menuItem3,
																					this.mnuCut,
																					this.mnuCopy,
																					this.mnuPaste,
																					this.mnuDelete,
																					this.menuItem11,
																					this.mnuSize,
																					this.mnuAdd,
																					this.mnuConnect,
																					this.menuItem20,
																					this.mnuOrder});
			this.mnuEdit.Text = "&Edit";
			// 
			// mnuUndo
			// 
			this.mnuUndo.Index = 0;
			this.mnuUndo.Text = "&Undo";
			this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
			// 
			// mnuRedo
			// 
			this.mnuRedo.Index = 1;
			this.mnuRedo.Text = "&Redo";
			this.mnuRedo.Click += new System.EventHandler(this.mnuRedo_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "-";
			// 
			// mnuCut
			// 
			this.mnuCut.Index = 3;
			this.mnuCut.Text = "Cu&t";
			this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
			// 
			// mnuCopy
			// 
			this.mnuCopy.Index = 4;
			this.mnuCopy.Text = "Cop&y";
			this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
			// 
			// mnuPaste
			// 
			this.mnuPaste.Index = 5;
			this.mnuPaste.Text = "Paste";
			this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
			// 
			// mnuDelete
			// 
			this.mnuDelete.Index = 6;
			this.mnuDelete.Text = "&Delete";
			this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 7;
			this.menuItem11.Text = "-";
			// 
			// mnuSize
			// 
			this.mnuSize.Index = 8;
			this.mnuSize.Text = "&Size";
			this.mnuSize.Click += new System.EventHandler(this.mnuSize_Click);
			// 
			// mnuAdd
			// 
			this.mnuAdd.Index = 9;
			this.mnuAdd.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mnuRectangle,
																				   this.mnuElipse,
																				   this.mnuRectangleNode,
																				   this.mnuElipseNode});
			this.mnuAdd.Text = "&Add";
			// 
			// mnuRectangle
			// 
			this.mnuRectangle.Index = 0;
			this.mnuRectangle.Text = "&Rectangle";
			this.mnuRectangle.Click += new System.EventHandler(this.mnuRectangle_Click);
			// 
			// mnuElipse
			// 
			this.mnuElipse.Index = 1;
			this.mnuElipse.Text = "&Elipse";
			this.mnuElipse.Click += new System.EventHandler(this.mnuElipse_Click);
			// 
			// mnuRectangleNode
			// 
			this.mnuRectangleNode.Index = 2;
			this.mnuRectangleNode.Text = "&Node Rectangle";
			this.mnuRectangleNode.Click += new System.EventHandler(this.mnuRectangleNode_Click);
			// 
			// mnuElipseNode
			// 
			this.mnuElipseNode.Index = 3;
			this.mnuElipseNode.Text = "N&ode Elipse";
			this.mnuElipseNode.Click += new System.EventHandler(this.mnuElipseNode_Click);
			// 
			// mnuConnect
			// 
			this.mnuConnect.Index = 10;
			this.mnuConnect.Text = "&Connect";
			this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 11;
			this.menuItem20.Text = "-";
			// 
			// mnuOrder
			// 
			this.mnuOrder.Index = 12;
			this.mnuOrder.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuBringToFront,
																					 this.mnuSendToBack,
																					 this.mnuMoveUp,
																					 this.mnuMoveDown});
			this.mnuOrder.Text = "&Order";
			// 
			// mnuBringToFront
			// 
			this.mnuBringToFront.Index = 0;
			this.mnuBringToFront.Text = "&Bring to Front";
			this.mnuBringToFront.Click += new System.EventHandler(this.mnuBringToFront_Click);
			// 
			// mnuSendToBack
			// 
			this.mnuSendToBack.Index = 1;
			this.mnuSendToBack.Text = "Send to &Back";
			this.mnuSendToBack.Click += new System.EventHandler(this.mnuSendToBack_Click);
			// 
			// mnuMoveUp
			// 
			this.mnuMoveUp.Index = 2;
			this.mnuMoveUp.Text = "Move &Up";
			this.mnuMoveUp.Click += new System.EventHandler(this.mnuMoveUp_Click);
			// 
			// mnuMoveDown
			// 
			this.mnuMoveDown.Index = 3;
			this.mnuMoveDown.Text = "Move &Down";
			this.mnuMoveDown.Click += new System.EventHandler(this.mnuMoveDown_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuShowDebugLog,
																					this.menuItem1,
																					this.mnuAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuShowDebugLog
			// 
			this.mnuShowDebugLog.Index = 0;
			this.mnuShowDebugLog.Text = "&Show Debug Log...";
			this.mnuShowDebugLog.Click += new System.EventHandler(this.mnuShowDebugLog_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "-";
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 2;
			this.mnuAbout.Text = "&About...";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.designer1);
			this.panel1.Controls.Add(this.splitter2);
			this.panel1.Controls.Add(this.txtLog);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.propertyGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(696, 359);
			this.panel1.TabIndex = 2;
			// 
			// designer1
			// 
			this.designer1.AutoScroll = true;
			this.designer1.AutoScrollMinSize = new System.Drawing.Size(100, 100);
			this.designer1.BackColor = System.Drawing.SystemColors.Window;
			this.designer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.designer1.Location = new System.Drawing.Point(0, 0);
			this.designer1.Name = "designer1";
			this.designer1.Size = new System.Drawing.Size(468, 252);
			this.designer1.TabIndex = 6;
			this.designer1.ElementMoving += new Dalssoft.DiagramNet.Designer.ElementEventHandler(this.designer1_ElementMoving);
			this.designer1.ElementMouseUp += new Dalssoft.DiagramNet.Designer.ElementMouseEventHandler(this.designer1_ElementMouseUp);
			this.designer1.ElementResizing += new Dalssoft.DiagramNet.Designer.ElementEventHandler(this.designer1_ElementResizing);
			this.designer1.ElementMoved += new Dalssoft.DiagramNet.Designer.ElementEventHandler(this.designer1_ElementMoved);
			this.designer1.ElementConnected += new Dalssoft.DiagramNet.Designer.ElementConnectEventHandler(this.designer1_ElementConnected);
			this.designer1.ElementConnecting += new Dalssoft.DiagramNet.Designer.ElementConnectEventHandler(this.designer1_ElementConnecting);
			this.designer1.ElementSelection += new Dalssoft.DiagramNet.Designer.ElementSelectionEventHandler(this.designer1_ElementSelection);
			this.designer1.ElementMouseDown += new Dalssoft.DiagramNet.Designer.ElementMouseEventHandler(this.designer1_ElementMouseDown);
			this.designer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.designer1_MouseUp);
			this.designer1.ElementClick += new Dalssoft.DiagramNet.Designer.ElementEventHandler(this.designer1_ElementClick);
			this.designer1.ElementResized += new Dalssoft.DiagramNet.Designer.ElementEventHandler(this.designer1_ElementResized);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(0, 252);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(468, 3);
			this.splitter2.TabIndex = 5;
			this.splitter2.TabStop = false;
			// 
			// txtLog
			// 
			this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtLog.Location = new System.Drawing.Point(0, 255);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(468, 104);
			this.txtLog.TabIndex = 4;
			this.txtLog.Text = "Log:";
			this.txtLog.Visible = false;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(468, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 359);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(472, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(224, 359);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "*.dgn";
			this.openFileDialog1.RestoreDirectory = true;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 385);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Diagram.NET Test Form";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();

			Application.Run(new Form1());
		}

		#region Functions
		private void Edit_UpdateUndoRedoEnable()
		{
			mnuUndo.Enabled = designer1.CanUndo;
			btnUndo.Enabled = designer1.CanUndo;
			mnuRedo.Enabled = designer1.CanRedo;
			btnRedo.Enabled = designer1.CanRedo;
		}

		private void Edit_Undo()
		{
			if (designer1.CanUndo)
				designer1.Undo();
			
			Edit_UpdateUndoRedoEnable();
		}

		private void Edit_Redo()
		{
			if (designer1.CanRedo)
				designer1.Redo();

			Edit_UpdateUndoRedoEnable();
		}

		private void Action_None()
		{
			mnuSize.Checked = false;
			mnuAdd.Checked = false;
			mnuDelete.Checked = false;
			mnuConnect.Checked = false;

			btnSize.Pushed = false;
			btnAdd.Pushed = false;
			btnDelete.Pushed = false;
			btnConnect.Pushed = false;

			mnuRectangle.Checked = false;
			mnuTbRectangle.Checked = false;
			mnuElipse.Checked = false;
			mnuTbElipse.Checked = false;
			mnuRectangleNode.Checked = false;
			mnuTbRectangleNode.Checked = false;
			mnuElipseNode.Checked = false;
			mnuTbElipseNode.Checked = false;
		}

		private void Action_Size()
		{
			Action_None();
			mnuSize.Checked = true;
			btnSize.Pushed = true;
			if (changeDocumentProp)
				designer1.Document.Action = DesignerAction.Select;
		}

		private void Action_Add(ElementType e)
		{
			Action_None();
			btnAdd.Pushed = true;
			switch(e)
			{
				case ElementType.Rectangle:
					mnuRectangle.Checked = true;
					mnuTbRectangle.Checked = true;
					break;
				case ElementType.Elipse:
					mnuElipse.Checked = true;
					mnuTbElipse.Checked = true;
					break;
				case ElementType.RectangleNode:
					mnuRectangleNode.Checked = true;
					mnuTbRectangleNode.Checked = true;
					break;
				case ElementType.ElipseNode:
					mnuElipseNode.Checked = true;
					mnuTbElipseNode.Checked = true;
					break;
			}
			
			if (changeDocumentProp)
			{
				designer1.Document.Action = DesignerAction.Add;
				designer1.Document.ElementType = e;
			}
		}

		private void Action_Delete()
		{
			Action_None();
			mnuDelete.Checked = true;
			btnDelete.Pushed = true;
			if (changeDocumentProp)
				designer1.Document.DeleteSelectedElements();
			Action_None();
		}

		private void Action_Connect()
		{
			Action_None();
			mnuConnect.Checked = true;
			btnConnect.Pushed = true;
			if (changeDocumentProp)
				designer1.Document.Action = DesignerAction.Connect;
		}

		private void Action_Connector(LinkType lt)
		{
			Action_None();
			switch(lt)
			{
				case LinkType.Straight:
					mnuTbStraightLink.Checked = true;
					mnuTbRightAngleLink.Checked = false;
					break;
				case LinkType.RightAngle:
					mnuTbStraightLink.Checked = false;
					mnuTbRightAngleLink.Checked = true;
					break;
			}
			designer1.Document.LinkType = lt;
			Action_Connect();
		}

		private void Action_Zoom(float zoom)
		{
			designer1.Document.Zoom = zoom;
		}

		private void File_Open()
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				designer1.Open(openFileDialog1.FileName);
			}
		}

		private void File_Save()
		{
			if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				designer1.Save(saveFileDialog1.FileName);
			}			
		}

		private void Order_BringToFront()
		{
			if (designer1.Document.SelectedElements.Count == 1)
			{
				designer1.Document.BringToFrontElement(designer1.Document.SelectedElements[0]);
				designer1.Refresh();
			}
		}

		private void Order_SendToBack()
		{
			if (designer1.Document.SelectedElements.Count == 1)
			{
				designer1.Document.SendToBackElement(designer1.Document.SelectedElements[0]);
				designer1.Refresh();
			}
		}

		private void Order_MoveUp()
		{
			if (designer1.Document.SelectedElements.Count == 1)
			{
				designer1.Document.MoveUpElement(designer1.Document.SelectedElements[0]);
				designer1.Refresh();
			}	
		}

		private void Order_MoveDown()
		{
			if (designer1.Document.SelectedElements.Count == 1)
			{
				designer1.Document.MoveDownElement(designer1.Document.SelectedElements[0]);
				designer1.Refresh();
			}	
		}

		private void Clipboard_Cut()
		{
			designer1.Cut();
		}

		private void Clipboard_Copy()
		{
			designer1.Copy();
		}

		private void Clipboard_Paste()
		{
			designer1.Paste();
		}

		#endregion

		#region Menu Events
		private void mnuUndo_Click(object sender, System.EventArgs e)
		{
			Edit_Undo();
		}

		private void mnuRedo_Click(object sender, System.EventArgs e)
		{
			Edit_Redo();
		}

		private void mnuSize_Click(object sender, System.EventArgs e)
		{
			Action_Size();		
		}

		private void mnuRectangle_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.Rectangle);
		}

		private void mnuElipse_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.Elipse);
		}

		private void mnuRectangleNode_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.RectangleNode);
		}

		private void mnuElipseNode_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.ElipseNode);
		}

		private void mnuDelete_Click(object sender, System.EventArgs e)
		{
			Action_Delete();
		}

		private void mnuCut_Click(object sender, System.EventArgs e)
		{
			Clipboard_Cut();
		}

		private void mnuCopy_Click(object sender, System.EventArgs e)
		{
			Clipboard_Copy();
		}

		private void mnuPaste_Click(object sender, System.EventArgs e)
		{
			Clipboard_Paste();
		}

		private void mnuConnect_Click(object sender, System.EventArgs e)
		{
			Action_Connect();
		}

		private void mnuBringToFront_Click(object sender, System.EventArgs e)
		{
			Order_BringToFront();
		}

		private void mnuSendToBack_Click(object sender, System.EventArgs e)
		{
			Order_SendToBack();
		}

		private void mnuMoveUp_Click(object sender, System.EventArgs e)
		{
			Order_MoveUp();
		}

		private void mnuMoveDown_Click(object sender, System.EventArgs e)
		{
			Order_MoveDown();
		}

		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
			File_Open();
		}

		private void mnuSave_Click(object sender, System.EventArgs e)
		{
			File_Save();		
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			About about = new About();
			about.ShowDialog(this);
		}
		#endregion

		#region Toolbar Events
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			
			string btn = (string) e.Button.Tag;
			
			if (btn == "Open") File_Open();
			if (btn == "Save") File_Save();
			
			if (btn == "Size") Action_Size();
			//if (btn == "Add")
			if (btn == "Delete") Action_Delete();
			if (btn == "Connect") Action_Connect();

			if (btn == "Undo") Edit_Undo();
			if (btn == "Redo") Edit_Redo();

			if (btn == "Front") Order_BringToFront();
			if (btn == "Back") Order_SendToBack();
			if (btn == "MoveUp") Order_MoveUp();
			if (btn == "MoveDown") Order_MoveDown();

			if (btn == "Cut") Clipboard_Cut();
			if (btn == "Copy") Clipboard_Copy();
			if (btn == "Paste") Clipboard_Paste();
		}

		private void mnuTbRectangle_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.Rectangle);
		}

		private void mnuTbElipse_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.Elipse);
		}

		private void mnuTbRectangleNode_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.RectangleNode);
		}

		private void mnuTbElipseNode_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.ElipseNode);
		}

		private void TbCommentBox_Click(object sender, System.EventArgs e)
		{
			Action_Add(ElementType.CommentBox);
		}

		private void mnuTbStraightLink_Click(object sender, System.EventArgs e)
		{
			Action_Connector(LinkType.Straight);
		}

		private void mnuTbRightAngleLink_Click(object sender, System.EventArgs e)
		{
			Action_Connector(LinkType.RightAngle);
		}

		#endregion

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Edit_UpdateUndoRedoEnable();
			
			//Events
			designer1.Document.PropertyChanged+=new EventHandler(Document_PropertyChanged);
		}

		private void Document_PropertyChanged(object sender, EventArgs e)
		{
			changeDocumentProp = false;

			Action_None();

			switch(designer1.Document.Action)
			{
				case DesignerAction.Select:
					Action_Size();
					break;
				case DesignerAction.Delete:
					Action_Delete();
					break;
				case DesignerAction.Connect:
					Action_Connect();
					break;
				case DesignerAction.Add:
					Action_Add(designer1.Document.ElementType);
					break;
			}

			Edit_UpdateUndoRedoEnable();

			changeDocumentProp = true;
		}

		private void mnuZoom_10_Click(object sender, System.EventArgs e)
		{
			Action_Zoom(0.1f);
		}

		private void mnuZoom_25_Click(object sender, System.EventArgs e)
		{
			Action_Zoom(0.25f);
		}

		private void mnuZoom_50_Click(object sender, System.EventArgs e)
		{
			Action_Zoom(0.5f);
		}

		private void mnuZoom_75_Click(object sender, System.EventArgs e)
		{
			Action_Zoom(0.75f);
		}

		private void mnuZoom_100_Click(object sender, System.EventArgs e)
		{
			Action_Zoom(1f);
		}

		private void mnuZoom_150_Click(object sender, System.EventArgs e)
		{
			Action_Zoom(1.5f);
		}

		private void mnuZoom_200_Click(object sender, System.EventArgs e)
		{
			Action_Zoom(2.0f);
		}

		private void mnuShowDebugLog_Click(object sender, System.EventArgs e)
		{
			mnuShowDebugLog.Checked = !mnuShowDebugLog.Checked;
			txtLog.Visible = mnuShowDebugLog.Checked;

		}

		#region Events Handling 
		private void designer1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			AppendLog("designer1_MouseUp: {0}", e.ToString());

			propertyGrid1.SelectedObject = null;

			if (designer1.Document.SelectedElements.Count == 1)
			{
				propertyGrid1.SelectedObject = designer1.Document.SelectedElements[0];
			}
			else if (designer1.Document.SelectedElements.Count > 1)
			{
				propertyGrid1.SelectedObjects = designer1.Document.SelectedElements.GetArray();
			}
			else if (designer1.Document.SelectedElements.Count == 0)
			{
				propertyGrid1.SelectedObject = designer1.Document;
			}
		}

		private void designer1_ElementClick(object sender, Dalssoft.DiagramNet.ElementEventArgs e)
		{
			AppendLog("designer1_ElementClick: {0}", e.ToString());
		}

		private void designer1_ElementMouseDown(object sender, Dalssoft.DiagramNet.ElementMouseEventArgs e)
		{
			AppendLog("designer1_ElementMouseDown: {0}", e.ToString());
		}

		private void designer1_ElementMouseUp(object sender, Dalssoft.DiagramNet.ElementMouseEventArgs e)
		{
			AppendLog("designer1_ElementMouseUp: {0}", e.ToString());
		}
		
		private void designer1_ElementMoved(object sender, Dalssoft.DiagramNet.ElementEventArgs e)
		{
			AppendLog("designer1_ElementMoved: {0}", e.ToString());
		}

		private void designer1_ElementMoving(object sender, Dalssoft.DiagramNet.ElementEventArgs e)
		{
			AppendLog("designer1_ElementMoving: {0}", e.ToString());
		}

		private void designer1_ElementResized(object sender, Dalssoft.DiagramNet.ElementEventArgs e)
		{
			AppendLog("designer1_ElementResized: {0}", e.ToString());
		}

		private void designer1_ElementResizing(object sender, Dalssoft.DiagramNet.ElementEventArgs e)
		{
			AppendLog("designer1_ElementResizing: {0}", e.ToString());
		}

		private void designer1_ElementConnected(object sender, Dalssoft.DiagramNet.ElementConnectEventArgs e)
		{
			AppendLog("designer1_ElementConnected: {0}", e.ToString());
		}

		private void designer1_ElementConnecting(object sender, Dalssoft.DiagramNet.ElementConnectEventArgs e)
		{
			AppendLog("designer1_ElementConnecting: {0}", e.ToString());
		}

		private void designer1_ElementSelection(object sender, Dalssoft.DiagramNet.ElementSelectionEventArgs e)
		{
			AppendLog("designer1_ElementSelection: {0}", e.ToString());
		}

		#endregion

		private void AppendLog(string log)
		{
			AppendLog(log, "");
		}

		private void AppendLog(string log, params object[] args)
		{
			if (mnuShowDebugLog.Checked)
				txtLog.AppendText(String.Format(log, args) + "\r\n");
		}

	}
}
