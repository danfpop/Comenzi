/* 
 * Pagina de parteneri
 *   - permite filtrarea catalogului de parteneri + CRUD
 *   
 *  pop.danut@email.com
 *  
 *  15.06.2019  - upd reject changes la cancel
 *  
 */

namespace ProiectComenzi.Parteneri {

    using Core;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class ParteneriVM : VMBase {
        public ParteneriVM() {
            Add = new RelayCommand(OnAdd);
            Edit = new RelayCommand(OnEdit, OnIsSelectedItem);
            Delete = new RelayCommand(OnDelete, OnIsSelectedItem);

            Search = new RelayCommand(OnSearch);
        }

        /// <summary>
        /// predicat pt. comenzile Edit si Delete
        /// </summary>      
        bool OnIsSelectedItem(object param) { return SelectedItem != null; }

        public ICommand Add { get; private set; }
        private void OnAdd() {
            var newPartener = new parteneri();
            var dlg = new EditPartener(newPartener);
            if (dlg.ShowDialog() == true) {
                Utils.Ctx.parteneris.Add(newPartener);
                Utils.Ctx.SaveChanges();
                RaisePropertyChanged("Items");
            }
        }

        public ICommand Edit { get; private set; }
        private void OnEdit() {
            var dlg = new EditPartener(SelectedItem);
            if (dlg.ShowDialog() == true) {
                Utils.Ctx.SaveChanges();
            }
            else {      // reject changes 
                Utils.Ctx.DbContextRejectChanges<parteneri>();
            }
            RaisePropertyChanged("Items");
        }


        public ICommand Delete { get; private set; }
        private void OnDelete() {

            // verificare: partenerul are comenzi ?
            var cmds = Utils.Ctx.comenzis
                .Where(c => c.id_partener == SelectedItem.id)
                .Take(10)
                .Select(c => c.nr).ToList<string>();

            if (cmds.Count > 0) {
                MessageBox.Show(
                    "Acest partener are comenzi - nr : \n" + string.Join("\n", cmds),
                    "Ștergere abandonată");
            }
            else if (Utils.Confirm("Confirmati ștergerea partenerului: " + SelectedItem.nume)) {
                Utils.Ctx.parteneris.Remove(SelectedItem);
                Utils.Ctx.SaveChanges();
                RaisePropertyChanged("Items");
            }
        }

        public ICommand Search { get; private set; }
        private void OnSearch() { RaisePropertyChanged("Items"); }

        public string SearchText { get; set; }

        /// <summary>
        /// Obiectul curent selectat din lista (dataGrid)
        /// </summary>
        public parteneri SelectedItem { get; set; }
        
        public IEnumerable<parteneri> Items {
            get {
                if (string.IsNullOrEmpty(SearchText)) {
                    return Utils.Ctx.parteneris
                        .ToList<parteneri>()
                        .OrderBy(p => p.nume);
                }
                else {
                    return Utils.Ctx.parteneris
                        .Where(p => p.nume.StartsWith(SearchText))
                        .ToList<parteneri>()
                        .OrderBy(p => p.nume);
                }
            }
        }
    }

}
