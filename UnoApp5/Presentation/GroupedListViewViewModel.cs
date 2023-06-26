using System.Collections;
using System.Net.Http.Headers;
using Microsoft.UI.Xaml.Data;

namespace UnoApp5.Presentation
{
    public partial class GroupedListViewViewModel : ObservableObject
    {
        private INavigator _navigator;

        [ObservableProperty]
        private string? name;

        public Entity Entity { get; set; }

        public GroupedListViewViewModel(
            INavigator navigator,
            Entity entity)
        {
            Entity = entity;
            _navigator = navigator;

            GroupedTownsAsSource = GetAsCollectionViewSource(GetTownsGroupedAlphabetically());
        }

        private static IEnumerable<IGrouping<string, string>> GetTownsGroupedAlphabetically()
        {
            return Enumerable.Range(1, 2)
                .Select(x => new EmptyGroup<string, string>(x.ToString()))
                .Concat(
                    // left join
                    from letter in _alphabet
                    join g in SampleTowns.GroupBy(x => x.Substring(0, 1))
                        on letter equals g.Key into groupedTowns
                    select groupedTowns.FirstOrDefault() ?? new EmptyGroup<string, string>(letter)
                )
                .ToList();
        }

        internal static IEnumerable<object> GetAsCollectionViewSource<T1, T2>(IEnumerable<IGrouping<T1, T2>> groups)
        {
            var source = new CollectionViewSource()
            {
                Source = groups,
                IsSourceGrouped = true
            }.View;

            return source;
        }

        private class EmptyGroup<TKey, TValue> : IGrouping<TKey, TValue>
        {
            private TKey _key;

            public EmptyGroup(TKey key)
            {
                _key = key;
            }

            public TKey Key => _key;

            IEnumerator IEnumerable.GetEnumerator() => Enumerable.Empty<object>().GetEnumerator();

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() => Enumerable.Empty<TValue>().GetEnumerator();
        }

        public IEnumerable<object> GroupedTownsAsSource { get; set; }

        private static readonly string[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => c.ToString()).ToArray();

        internal static readonly string[] SampleTowns =
        {
            "L'�le-Dorval",
            "Barkmere",
            "L'�le-Cadieux",
			//"Est�rel",
			"Schefferville",
            "Lac-Saint-Joseph",
            "Belleterre",
            "Lac-Sergent",
            "Scotstown",
            "Lac-Delage",
            "M�tis-sur-Mer",
            "Duparquet",
            "Murdochville",
            "Daveluyville",
            "Desbiens",
            "Matagami",
            "Chapais",
            "Fossambault-sur-le-Lac",
            "Saint-Joseph-de-Sorel",
            "Saint-Ours",
            "Kingsey Falls",
            "Waterville",
            "Lebel-sur-Qu�villon",
            "L�ry",
            "Valcourt",
            "Gracefield",
            "T�miscaming",
            "Thurso",
            "Huntingdon",
            "Causapscal",
            "Saint-Basile",
            "Disraeli",
            "Ville-Marie",
            "Cap-Chat",
            "Bedford",
            "Saint-Pamphile",
            "Macamic",
            "Sainte-Marguerite-du-Lac-Masson",
            "Poh�n�gamook",
            "Bonaventure",
            "Saint-Gabriel",
            "Sainte-Anne-de-Beaupr�",
            "Stanstead",
            "Saint-Marc-des-Carri�res",
            "Fermont",
            "Senneterre",
            "Cap-Sant�",
            "D�gelis",
            "Portneuf",
            "Clermont",
            "Normandin",
            "Pasp�biac",
            "Forestville",
            "Richmond",
            "Perc�",
            "Beaupr�",
            "Malartic",
            "Grande-Rivi�re",
            "Trois-Pistoles",
            "Dunham",
            "Saint-Pascal",
            "Montr�al-Est",
			//"East Angus",
			"New Richmond",
            "Ch�teau-Richer",
            "Baie-D'Urf�",
            "Saint-Tite",
            "Neuville",
            "Sutton",
            "Maniwaki",
            "Carleton-sur-Mer",
            "Danville",
            "Berthierville",
            "M�tabetchouan�Lac-�-la-Croix",
            "La Pocati�re",
            "Waterloo",
            "Rivi�re-Rouge",
            "Saint-Joseph-de-Beauce",
            "Warwick",
            "Sainte-Anne-de-Bellevue",
            "Montreal West",
            "T�miscouata-sur-le-Lac",
            "Hudson",
            "Cookshire-Eaton",
            "L'�piphanie",
            "Windsor",
            "Saint-Pie",
            "Richelieu",
            "Brome Lake",
            "Saint-C�saire",
            "Princeville",
            "Charlemagne",
            "Lac-M�gantic",
            "Contrecoeur",
            "Donnacona",
            "Sainte-Catherine-de-la-Jacques-Cartier",
            "Amqui",
            "Beauceville",
            "Port-Cartier",
            "Mont-Joli",
            "Plessisville",
            "Coteau-du-Lac",
            "Sainte-Anne-des-Monts",
            "Asbestos",
            "Hampstead",
            "Brownsburg-Chatham",
            "Saint-R�mi",
            "Baie-Saint-Paul",
            "Delson",
            "Louiseville",
            "Chibougamau",
            "Bromont",
            "Acton Vale",
            "Chandler",
            "La Sarre",
            "Nicolet",
            "Carignan",
            "Farnham",
			//"Otterburn Park",
			"Pont-Rouge",
            "La Malbaie",
            "Notre-Dame-des-Prairies",
            "Coaticook",
            "Lorraine",
            "Bois-des-Filion",
            "Mont-Tremblant",
            "Saint-Raymond",
            "Saint-Sauveur",
            "Marieville",
            "Sainte-Agathe-des-Monts",
            "Roberval",
            "Saint-F�licien",
            "L'�le-Perrot",
            "Notre-Dame-de-l'�le-Perrot",
            "La Tuque",
            "Montmagny",
            "Mercier",
            "Beauharnois",
            "Sainte-Ad�le",
            "Pr�vost",
            "B�cancour",
            "Cowansville",
            "Lachute",
            "Amos",
            "Sainte-Marie",
            "Saint-Colomban",
            "Lavaltrie",
            "Mont-Laurier",
            "Rosem�re",
            "Pincourt",
            "Dolbeau-Mistassini",
            "Matane",
            "Sainte-Anne-des-Plaines",
            "Gasp�",
            "Sainte-Marthe-sur-le-Lac",
            "Saint-Basile-le-Grand",
            "L'Ancienne-Lorette",
            "Sainte-Catherine",
            "Saint-Lin-Laurentides",
            "Deux-Montagnes",
            "Saint-Augustin-de-Desmaures",
            "Mont-Saint-Hilaire",
            "Dorval",
            "Saint-Lazare",
            "Rivi�re-du-Loup",
            "Mount Royal",
            "Beaconsfield",
            "Joliette",
            "Candiac",
            "Westmount",
            "L'Assomption",
            "Beloeil",
            "Varennes",
            "Kirkland",
            "Saint-Lambert",
            "Baie-Comeau",
            "La Prairie",
            "Saint-Constant",
            "Magog",
            "Chambly",
            "Sept-�les",
            "Thetford Mines",
            "Sainte-Th�r�se",
            "Saint-Bruno-de-Montarville",
            "Boisbriand",
            "Sainte-Julie",
            "Pointe-Claire",
            "Alma",
            "Saint-Georges",
            "Val-d'Or",
            "C�te Saint-Luc",
            "Vaudreuil-Dorion",
            "Sorel-Tracy",
            "Salaberry-de-Valleyfield",
            "Boucherville",
            "Rouyn-Noranda",
            "Mirabel",
            "Mascouche",
            "Victoriaville",
            "Saint-Eustache",
            "Ch�teauguay",
            "Rimouski",
            "Dollard-des-Ormeaux",
            "Shawinigan",
            "Saint-Hyacinthe",
            "Blainville",
            "Granby",
            "Saint-J�r�me",
            "Drummondville",
            "Brossard",
            "Repentigny",
            "Saint-Jean-sur-Richelieu",
            "Terrebonne",
            "Trois-Rivi�res",
            "L�vis",
            "Saguenay",
            "Sherbrooke",
            "Longueuil",
            "Gatineau",
            "Laval",
            "Qu�bec",
            "Montreal",
        };

    }
}