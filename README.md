# TShTask

Билд: https://dropmefiles.com/SRJdD

В ТЗ использована ESC - LeoESC
Основные файлы проекта лежат в ShooterTW
- Data/StaticData.asset - содержит настройки игрового баланса (игрок, его здоровье/защита) и префабы врагов.
- Настройка оружия идет через компонент WeaponSettings, прикрепленный к игроку
- Урон рассчитывается в DamageSystem, путь: Scripts/Runtime/Systems/Combat
- Настройка здоровья монстров на каждом префабе монстра компонент EnemyView