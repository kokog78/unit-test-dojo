namespace dojo;


/**
 * Jelszó ellenőrzésére szolgáló osztályka.
 * A  {@link #verify(String)} metódus kap egy jelszót, amit ellenőriz.
 * Ha az alábbi feltételek közül bármelyik NEM teljesül, akkor {@link IllegalArgumentException}-t dob.
 * <ul>
 * <li>A jelszó nem <code>null</code>.</li>
 * <li>A jelszó legalább 8 karakter hosszú.</li>
 * <li>A jelszó tartalmaz legalább egy számot.</li>
 * <li>A jelszó tartalmaz legalább egy kisbetűt.</li>
 * <li>A jelszó tartalmaz legalább egy nagybetűt.</li>
 * </ul>
 */
public class PasswordVerifier
{
    public void Verify(string password)
    {

    }

}
