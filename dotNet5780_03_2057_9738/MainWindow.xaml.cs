using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5780_03_2057_9738
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Host currentHost;

        public MainWindow()
        {
            InitializeComponent();
            cbHostList.ItemsSource = hostList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;
        }
        List<Host> hostList = new List<Host>()
            {
                new Host()
                {
                    HostName = "first-hotel ",
                    Unit = new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName = "aliBaba",
                            Rooms = 3,
                            IsSwimmingPool = true,
                            AllOrders = new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJCl_jJI7yliRCTYrZlS04R3jfdBpZReD2Klot3dqYVPOY8fnFzw&s",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0HCSVL-o5pZxsEHmNgFHKXVPixAEN6u01Uqf0RH2qX1Mh4cuJ&s",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL3VqpjmPtG2_Ak2kq2bBZ9LJNGYwIF2B517pVueNEm2uukce0kA&s"
                            }
                        },
                        new HostingUnit()
                        {
                            UnitName = "infinity_Motel",
                            Rooms = 2,
                            IsSwimmingPool = false,
                            AllOrders = new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSg4Y9bmqiZcp3TzvfxwdZJmX2hH2_zbbIy2EepwuWpPYpdoOi4&s",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmdYeey2bhSAB7yKOsuY_EbJF0-y3HUg96QIILaTb1mxkrOwvTrg&s"
                            }
                        }
                    }
                },


                new Host()
                {
                    HostName = "second-hotel ",
                    Unit = new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName = "wow",
                            Rooms = 3,
                            IsSwimmingPool = true,
                            AllOrders = new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                 "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJCl_jJI7yliRCTYrZlS04R3jfdBpZReD2Klot3dqYVPOY8fnFzw&s",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0HCSVL-o5pZxsEHmNgFHKXVPixAEN6u01Uqf0RH2qX1Mh4cuJ&s",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL3VqpjmPtG2_Ak2kq2bBZ9LJNGYwIF2B517pVueNEm2uukce0kA&s"
                            }
                        },
                        new HostingUnit()
                        {
                            UnitName = "Gimlet",
                            Rooms = 2,
                            IsSwimmingPool = false,
                            AllOrders = new List<DateTime>(),
                            Uris = new List<string>()
                            { 
                                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSg4Y9bmqiZcp3TzvfxwdZJmX2hH2_zbbIy2EepwuWpPYpdoOi4&s",
                            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmdYeey2bhSAB7yKOsuY_EbJF0-y3HUg96QIILaTb1mxkrOwvTrg&s"
                            }
                        }
                    }
                },


                new Host()
                {
                    HostName = "third-hotel ",
                    Unit = new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName = "sunrise",
                            Rooms = 3,
                            IsSwimmingPool = true,
                            AllOrders = new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://images.app.goo.gl/UJLB1ersz8NkBLmN6",
                                "https://images.app.goo.gl/b7aJBAqhErYYnV4u8",
                                "https://images.app.goo.gl/2UnRAKd13HQKZDkP7"
                            }
                        },
                        new HostingUnit()
                        {
                            UnitName = "Mojito",
                            Rooms = 2,
                            IsSwimmingPool = false,
                            AllOrders = new List<DateTime>(),
                            Uris = new List<string>()
                            {
                                "https://images.app.goo.gl/rMomxPQoQQ769XRR7",
                                "https://images.app.goo.gl/Dy29PxQ5YRxS9tYCA"
                            }
                        }
                    }
                }
            };

        private void cbHostList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }
        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostList[index];
            UpGrid.DataContext = currentHost;
            for (int i = 0; i < currentHost.Unit.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Unit[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }
    }
}
