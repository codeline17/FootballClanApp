using Smaug.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smaug.Models
{


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class highlights
    {

        private highlightsLeague[] leagueField;

        private string updatedField;

        private string sportField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("league")]
        public highlightsLeague[] league
        {
            get
            {
                return this.leagueField;
            }
            set
            {
                this.leagueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sport
        {
            get
            {
                return this.sportField;
            }
            set
            {
                this.sportField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class highlightsLeague
    {

        private highlightsLeagueMatch[] matchField;

        private string nameField;

        private ushort idField;

        private string sub_idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("match")]
        public highlightsLeagueMatch[] match
        {
            get
            {
                return this.matchField;
            }
            set
            {
                this.matchField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sub_id
        {
            get
            {
                return this.sub_idField;
            }
            set
            {
                this.sub_idField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class highlightsLeagueMatch
    {

        private highlightsLeagueMatchHome homeField;

        private highlightsLeagueMatchAway awayField;

        private string[] match_highlightsField;

        private string alternate_idField;

        private uint alternate_id_2Field;

        private string dateField;

        private string idField;

        private string static_idField;

        private string statusField;

        private string timeField;

        /// <remarks/>
        public highlightsLeagueMatchHome home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        public highlightsLeagueMatchAway away
        {
            get
            {
                return this.awayField;
            }
            set
            {
                this.awayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("match_highlight", IsNullable = false)]
        public string[] match_highlights
        {
            get
            {
                return this.match_highlightsField;
            }
            set
            {
                this.match_highlightsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string alternate_id
        {
            get
            {
                return this.alternate_idField;
            }
            set
            {
                this.alternate_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint alternate_id_2
        {
            get
            {
                return this.alternate_id_2Field;
            }
            set
            {
                this.alternate_id_2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string static_id
        {
            get
            {
                return this.static_idField;
            }
            set
            {
                this.static_idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class highlightsLeagueMatchHome
    {

        private byte goalsField;

        private string idField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte goals
        {
            get
            {
                return this.goalsField;
            }
            set
            {
                this.goalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class highlightsLeagueMatchAway
    {

        private byte goalsField;

        private string idField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte goals
        {
            get
            {
                return this.goalsField;
            }
            set
            {
                this.goalsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }



}
