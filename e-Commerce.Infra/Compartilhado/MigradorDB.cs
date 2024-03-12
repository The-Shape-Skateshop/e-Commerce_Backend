﻿namespace e_Commerce.Infra.Compartilhado
{
    public class MigradorDb
    {
        public bool AtualizarDb(DbContext eAgendaDb)
        {
            int qtdMigracoesPendentes = eAgendaDb.Database.GetPendingMigrations().Count();

            if (qtdMigracoesPendentes == 0)
            {
                return false;
            }

            eAgendaDb.Database.Migrate();

            return qtdMigracoesPendentes > 0;
        }
    }
}
