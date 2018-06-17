# A marsjáró-kihívás
(Eredeti származási hely: https://github.com/eXigentCoder/dojo-tdd)

Marsjárókat a marsi terep felmérése miatt küldenek a Marsra. Az egyik ilyen eszköz navigációs rendszerét te fogod programozni.
Ezeket az instrukciókat kaptad:

 - A Mars felszíne zónákra osztható. Minden zóna egy kétdimenziós derékszögű koordináta-rendszerrel modellezhető.
   Az egyes zónákat korábban gondosan feltérképezték, így a zónahatárok közötti felderítés teljesen biztonságos.
   A marsjáró pozícióját egyetlen derékszögű koordináta jelöli, pl. (5,5).
 - A marsjáró képes az égtájak értelmezésére. Vagy kelet felé (`E`), vagy nyugat felé (`W`), vagy észak felé (`N`), vagy pedig
   dél felé (`S`) áll.
 - A marsjáró az alábbi parancsokat érti meg:
    - `M`: mozgás egy egységgel előre (abba az irányba, amerre éppen áll)
    - `R`: fordulás 90 fokkal jobbra
    - `L`: fordulás 90 fokkal balra
 - Az átviteli idő miatt a marsjáróval történő kommunikáció lassú, csupán arra van lehetőség, hogy parancsok sorozatát küldd el.
   A marsjáró egymás után végrehajtja ezeket a parancsokat, és a végén visszaküldi az aktuális pozícióját az irányítóközpontnak.

Egy példa a marsjárónak küldött parancsokra:

```
8 8
1 2 E
MMLMRMMRRMML
```

A marsjáró így értelmezi a paracsokat:

 - Az első sor arról ad információt, hogy az aktuális zóna milyen nagy. A zóna határpontja a 8,8 derékszögű koordinátával rendelkezik,
   vagyis a zóna 64 blokkból áll.
 - A második sor a marsjáró kezdeti pozícióját és orientációját jelöli. A marsjáró az első (`1`) horizontális és a második (`2`) vertikális
   pocícióból indul, és kelet felé (`E`) néz.
 - A harmadik sor a végrehajtandó parancsok listája. Ezek egyaránt tartalmaznak mozgási és forgási parancsokat.

A marsjáró `1 2 E`-ből indulva és a fenti parancsokat végrehajtva `3 3 S`-be érkezik. Ez a navigációs művelet végeredménye.

Készítened kell egy programot, ami egy szövegfájlból beolvassa a fentihez hasonló parancsokat, és kiírja a marsjáró befejező
pocícióját a konzolra.
