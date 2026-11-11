Receptgyűjtemény - Fontos tudnivalók, használati utasítás

- Az egész alkalmazás SDK NET 9.0-ra épül, 10.0 helyett.
- Adatbázis: receptek_projekt.sql - XAMPP segítségével elindítani, ha minden igaz 3306 porton.
- API: ReceptApi - Elindítani, ha minden igaz 5000 porton.
- Amennyiben más porton fut az adatbázis vagy az API, át kell írni a C# kódban az elérési helyet.

Alkalmazás funkciói:
- 90db alapértelmezett recept, hozzávalókkal, stb-vel. (30db/kategória)
- Kulcsszavas keresés (egyaránt nézi a hozzávalókat, és az étel nevét)
- Mindhárom kategória külön-külön megjelenítése
- Extra: "Mit egyek ma?" -> Az összes adatbázisban lévő receptből kiválaszt egy teljesen randomot gombnyomásra.
- Új recept hozzáadása
- Recept törlése