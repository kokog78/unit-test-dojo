namespace dojo;

public class ComperableVersions
{
    /**
       * Ezt az osztályt arra szeretnénk majd használni, hogy konfigurációs fájlokban megadott
       * verziószámokkal tudjunk műveleteket megadni. Egyrészről össze szeretnénk hasonlítani
       * két verziószámot - erre való a {@link #CompareTo(ComparableVersion)} metódus.
       * Másrészről az egyes verziószámokat engedélyezni vagy tiltani szeretnénk - erre való
       * a {@link #SetEnabled(boolean)} ill. az {@link #IsEnabled()} metódus.
       */
    public class ComparableVersion : IComparable<ComparableVersion>
    {
        private static HashSet<ComparableVersion> enabledVersions = new HashSet<ComparableVersion>();
        private readonly int[] parts;

        public ComparableVersion(string version)
        {
            this.parts = CreateParts(version);
        }

        public int CompareTo(ComparableVersion? otherVersion)
        {
            int limit = Math.Min(parts.Length, otherVersion.parts.Length);
            for (int i = 0; i < limit; i++)
            {
                int currentResult = parts[i] - otherVersion.parts[i];
                if (currentResult != 0)
                {
                    return currentResult;
                }
            }
            return otherVersion.parts.Length - parts.Length;
        }

        public override bool Equals(object? otherObject)
        {
            return (otherObject is ComparableVersion) && CompareTo((ComparableVersion)otherObject) == 0;
        }

        /**
         * A verziószám engedélyezett?
         */
        public bool IsEnabled()
        {
            lock (enabledVersions)
            {
                return enabledVersions.Contains(this);
            }
        }

        /**
         * Engedélyezi vagy tiltja a verziószámot.
         * Ha a paraméter <code>true</code>: engedélyezi.
         * Ha a paraméter <code>false</code>: tiltja.
         */
        public void SetEnabled(bool enabled)
        {
            lock (enabledVersions)
            {
                if (enabled)
                {
                    enabledVersions.Add(this);
                }
                else
                {
                    enabledVersions.Remove(this);
                }
            }
        }

        private int[] CreateParts(string version)
        {
            string[] strArray = version.Split('.');
            int[] result = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                result[i] = int.Parse(strArray[i]);
            }
            return result;
        }
    }

}
