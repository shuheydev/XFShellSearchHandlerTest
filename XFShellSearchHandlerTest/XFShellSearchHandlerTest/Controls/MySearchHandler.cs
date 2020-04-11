using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFShellSearchHandlerTest.Models;

namespace XFShellSearchHandlerTest.Controls
{
    class MySearchHandler : SearchHandler
    {
        private IList<Person> _peoples;

        public MySearchHandler()
        {
            InitTestData();
        }

        private void InitTestData()
        {
            _peoples = new List<Person>();

            _peoples.Add(new Person { FirstName = "Person1", Age = 10 });
            _peoples.Add(new Person { FirstName = "Person2", Age = 20 });
            _peoples.Add(new Person { FirstName = "Person3", Age = 30 });
            _peoples.Add(new Person { FirstName = "Person4", Age = 40 });

        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = _peoples.Where(p => p.FirstName.ToLower()
                                                             .Contains(newValue.ToLower()))
                                      .ToList<Person>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
        }
    }
}
