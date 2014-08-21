using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StructureMap;
using ESCore;
namespace UIForm
{
    public partial class Form1 : Form
    {
        private Guid _currentGuid;
        private StructureMap.IContainer _container;
        private ICommandBus _commandBus;
        private IRepository<Item> _repository;
        private bool _isNew;
        public Form1(StructureMap.IContainer container, ICommandBus commandBus, IRepository<Item> repository)
        {
            _repository = repository;
            _container = container;
            _commandBus = commandBus;
            _isNew = true;
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (_isNew == true)
            {
                _currentGuid = Guid.NewGuid();
                _commandBus.Send(new CreateItemCommand(_currentGuid, descriptionTxt.Text, -1));
                createBtn.Text = "Update";
                _isNew = false;
            }
            else
            {
                var item = _repository.GetById(_currentGuid);
                _commandBus.Send(new ChangeItemDescriptionCommand(_currentGuid, descriptionTxt.Text, item.Version));
            }
            
        }

        private void completedChb_CheckedChanged(object sender, EventArgs e)
        {
            //_commandBus.Send(new ChangeItemDescriptionCommand)
            var item = _repository.GetById(_currentGuid);
            _commandBus.Send(new ChangeItemCompletedCommand(_currentGuid, completedChb.Checked, item.Version));
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
            _container.GetInstance<EventsList>().Show();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            _isNew = true;
            descriptionTxt.Text = "";
            createBtn.Text = "Create";
        }
    }
}
