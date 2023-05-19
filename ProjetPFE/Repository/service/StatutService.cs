using ProjetPFE.Contracts.services;
using ProjetPFE.Helpers;

namespace ProjetPFE.Repository.service
{
    public class StatutService : IStatutService 
    {
        public statut GetStatutDemande(statut statut_chef, statut statut_rh, statut statut_ds)
        {
            statut statut_demande;

            if (statut_chef == statut.En_attente)
            {
                statut_demande = statut.En_cours;
                statut_rh = statut.En_cours;
                statut_ds = statut.En_cours;
            }
            else if (statut_chef == statut.Acceptée)
            {
                if (statut_rh == statut.Acceptée)
                {
                    if (statut_ds == statut.Acceptée)
                    {
                        statut_demande = statut.Acceptée;
                    }
                    else if (statut_ds == statut.Refusée)
                    {
                        statut_demande = statut.Refusée;
                    }
                    else
                    {
                        statut_demande = statut.En_attente;
                        statut_ds = statut.En_attente;
                    }
                }
                else if (statut_rh == statut.Refusée)
                {
                    statut_demande = statut.Refusée;
                    statut_ds = statut.En_cours;
                }
                
                else
                {
                    statut_demande = statut.En_attente;
                    statut_rh = statut.En_attente;
                    statut_ds = statut.En_cours;
                }

            }
            else if (statut_chef == statut.En_cours && statut_rh == statut.En_cours && statut_ds == statut.En_cours)
            {
                statut_demande = statut.En_cours;
            }
            else // statut_chef == statut.refuse
            {
                statut_demande = statut.Refusée;
                statut_rh = statut.En_cours;
                statut_ds = statut.En_cours;
            }
            

            return statut_demande;
        }

    }
}
