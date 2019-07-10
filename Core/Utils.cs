using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectComenzi.Core {
    public static class Utils {


        public static bool Confirm(string message) {
            return ConfirmWnd.Show(message);
        }
        // simple DbContext Extension method
        public static void DbContextRejectChanges<T>(this DbContext ctx) {
            foreach (var item in ctx.ChangeTracker.Entries<parteneri>()) {
                if (item.State == EntityState.Modified) item.State = EntityState.Unchanged;
            }
        }

        public static void DbContextRejectChanges(this DbContext ctx) {
            foreach (var item in ctx.ChangeTracker.Entries()) {
                if (item.State == EntityState.Modified) item.State = EntityState.Unchanged;
            }
        }

        //simple Singleton
        private static comenziEntities _ctx;
        public static comenziEntities Ctx {
            get {
                if (_ctx == null) _ctx = new comenziEntities();
                return _ctx;
            }
        }

    }
}
