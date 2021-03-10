using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// ClassNotify er den class, som alle de classes vi benytter i vores solution, skal nedarve for at kunne benytte PropertyChangedEventHandler.
    /// Dette gøres ved at ClassNotify implementere interfacet INotifyPropertyChanged, som sikre os adgang til System.ComponentModel og derved
    /// funktionaliteten der kan opdatere objekter på GUI med data fra et Property.
    /// 
    /// Denne class har til formål at sende data fra dypt inde i vores kode, ud til GUI'en. 
    /// Dette gør den ved at når et Property bliver ændret så køre koden den metode some denne class indeholder, Notify, som den har
    /// adgang til gennem nedavning, der finder det property/field som er blevet ændret, via navn, kører Propertiets Get til at få 
    /// dataen. Den smider så den data op i et interface (en type kode, lidt ala metode men ikke) som sender det ud til GUI'en.
    /// Interfacet må være i stand til at se vilket Object af GUI'en er binded til hvilket Property/Field. Siden hværken Notify
    /// eller Propertien/Fielded indeholder den data.
    /// Måske, maybe, hvis jeg forstår det rigtigt. 
    /// </summary>
    public class ClassNotify : INotifyPropertyChanged
    {
        /// <summary>
        /// I alle Classes der bruger eller nedarver INotifyPropertyChanged, vil interfacet altid forlange at der generes en 
        /// public event af datatypen PropertyChangedEventHandler som default navngives PropertyChanged.
        /// Det er gennem denne instans, at der skabes forbindelse til det bagved liggende kode-bibliotek i System.ComponentModel.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// En default constructor
        /// </summary>
        public ClassNotify()
        {

        }

        /// <summary>
        /// Metoden Notify erklæret protected, for at sikre at metoden KUN kan benyttes gennem nedarvning. 
        /// Ved kald til metoden SKAL der parameteroverføres en string med navnet på den Property der er blevet opdateret.
        /// For ikke at risikere, at man overloader systemet, knotroleres fer først for om der realt er foretaget en opdatering
        /// af et Property i den respekitve class.
        /// Hvis der er registreret en opdatering i classen, udføres eventhandleren PropertyChanged.
        /// Eventhandleren PropertyChanged skal medsende to parameter: 
        ///     -   Første parameter er en enstands af den class eventen er foretaget i, dette gøres ved at benytte koden "This"
        ///     -   ("This" er et resaveret ord some tager navenet på den class det blev skrævet i. Altså hvis denne metode bliver 
        ///         tilgået gennem nedarvning vil This blive til navnet på classen der nedarvet den.)
        ///     -   Anden parameter er en ny instans af PropertyChangedEventArgs, som skal instantiseres med en textstreng som 
        ///         holder navnet på det Property der er blevet opdateret.
        ///         
        /// Herved overføres værdien der knytter sig til det nævnte property til det objekt på GUI som er binded via navnet på Property'en.
        /// </summary>
        /// <param name="propertyName">string (Navnet på det Proporty/Field/variable some blev ændret)</param>
        protected void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
