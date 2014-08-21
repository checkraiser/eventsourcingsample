using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESCore;
namespace UIForm
{
    public partial class EventsList : Form
    {
        private StructureMap.IContainer _container;
        private IEventStorage _storage;
        public EventsList(StructureMap.IContainer container, IEventStorage storage)
        {
            _container = container;
            _storage = storage;
            InitializeComponent();
        }

        private void EventsList_Load(object sender, EventArgs e)
        {
            var items = listView1.Items;
            foreach (var t in _storage.Events().ToArray())
            {
                items.Add(t.ToString());
            }
        }
    }
}
