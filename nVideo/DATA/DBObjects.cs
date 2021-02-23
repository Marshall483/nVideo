using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA
{
    public class DBObjects
    {
        private static Dictionary<string, Catalog_Category> _categories;
        private static Dictionary<string, Catalog_Entity> _entities;

        private static Dictionary<Catalog_Attribute, Catalog_Value> _attrValuePairs;

        private static Image[] _images;

        public static void Initial(AppDBContext content)
        {
            //if (!content.Cities.Any())
            //    content.Cities.AddRange(Cities);

            if (!content.Categories.Any()) // Если данных нет => Заполнить данными
                content.Categories.AddRange(Category.Select(c => c.Value));

            if (!content.Attributes.Any())
                content.Attributes.AddRange(AttrValuePairs.Select(a => a.Key));

            if (!content.Values.Any())
                content.Values.AddRange(AttrValuePairs.Select(v => v.Value));

            if (!content.Images.Any())
                content.Images.AddRange(_images);

            //if (!content.Entities.Any())
            //    content.Entities.AddRange(_entities);

            content.SaveChanges();
        }

        public static Dictionary<string, Catalog_Category> Category { 
            get {
                if(_categories == null){
                    var catesories = new List<Catalog_Category>{
                        new Catalog_Category { CategoryName = "Телефоны и гаджеты" },
                        new Catalog_Category { CategoryName = "Телевизоры и аудио" },
                        new Catalog_Category { CategoryName = "Ноутбуки и компьютеры" },
                        new Catalog_Category { CategoryName = "Техника для кухни" },
                        new Catalog_Category { CategoryName = "Техника для дома" },
                        new Catalog_Category { CategoryName = "Игры и софт, равлечения" },
                        new Catalog_Category { CategoryName = "Красота и здоровье" },
                        new Catalog_Category { CategoryName = "Фото и видео" },
                        new Catalog_Category { CategoryName = "Авто электроника" },
                        new Catalog_Category { CategoryName = "Аксессуары" }
                    };

                    foreach (var cat in catesories)
                        _categories.Add(cat.CategoryName, cat);

                    return _categories;
                }
                return _categories;
            }
        }

        public static Dictionary<string, Catalog_Entity> Entities { 
            get{
                 if(_entities == null){


                        var entities = new List<Catalog_Entity>{

                            #region Телефоны и гаджеты

                            new Catalog_Entity {
                                Name = "Apple iPhone 12 128GB Black",
                                Articul = "0001-0001",
                                Price = 84990,
                                Short_Desc = "iPhone 12. Во-первых, это быстро.",
                                Long_Desc =
@"iPhone 12 поражает возможностями. A14 Bionic, самый быстрый процессор iPhone. Новая система двух камер. И великолепный дисплей Super Retina XDR, на котором видно каждую деталь.

Великолепный яркий дисплей Super Retina XDR 6,1 дюйма.1 Передняя панель Ceramic Shield, с которой риск повреждений дисплея при падении в 4 раза ниже.2 Потрясающее качество снимков при слабом освещении благодаря Ночному режиму на всех камерах. Съёмка, монтаж и воспроизведение видео кинематографического качества в стандарте Dolby Vision. Мощный процессор A14 Bionic. И новые аксессуары MagSafe, которые мгновенно примагничиваются и обеспечивают более быструю беспроводную зарядку.3 Другими словами, вас ждут яркие открытия.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телефоны и гаджеты"]
                            },

                            new Catalog_Entity {
                                Name = "Xiaomi Mi 10T 8+128GB Black",
                                Articul = "0001-0002",
                                Price = 40990,
                                Short_Desc = "Xiaomi",
                                Long_Desc = 
@"Модуль задней камеры включает в себя 3 объектива. Присутствует основная камера и две дополнительные: сверхширокоугольная камера в 13 Мп (охватывает угол обзора 123°), а также макрообъектив в 6 Мп (поддерживает автофокус на расстоянии до 2 см).

Такая комбинация объективов превращает каждый снимок в произведение искусства. Видео записывается в качестве 8К. Возможна съемка в режиме длинной выдержки. Передняя камера имеет 20 Мп.

Гаджеты оснащены экраном в 6,67 дюйма с самой высокой частотой обновления изображения в истории Xiaomi – 144 Гц. Это на 140 % больше, чем 60 Гц. Время отклика дисплея составляет 7 мс. Значительно улучшен игровой процесс. Поддерживаются DCI-P3, MEMC и TrueColor. Технология AdaptiveSync (умный дисплей) автоматически настраивает для того или иного приложения необходимую частоту обновления (диапазон 30-144 Гц). Это обеспечивает максимальную плавность изображения и экономит энергопотребление (до 8 % после 6 часов использования).
                                В смартфоны встроен процессор Qualcomm Snapdragon 865. Поддерживается Wi-Fi 6.

Xiaomi Mi 10T имеют мощный аккумулятор с емкостью 5000 мАч. Обеспечивается быстрая проводная зарядка (33 Вт). Цикл полной зарядки до 100 % составляет 59 минут.

Устройства также характеризуются линейным вибрационным двигателем Х-оси, многофункциональным NFC, двойными динамиками (более объемный звук). Поддерживается технология LiquidCool и 3D-запись. В боковой части корпуса расположен сканер отпечатков пальцев.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телефоны и гаджеты"]
                            },

                            new Catalog_Entity {
                                Name = @"OnePlus 8 Pro 12/256Gb Black",
                                Articul = "0001-0003",
                                Price = 63620,
                                Short_Desc = "OnePlus",
                                Long_Desc =
@"Смартфон OnePlus 8 Pro 8/128Gb Black (черного цвета) - совершенство, доступное каждому
Высокопроизводительная конфигурация на основе Qualcomm, большой ресурс памяти, оптика топ-уровня, аккумулятор с увеличенным ресурсом, защита девайса и внутренних данных, сбалансированная акустика, NFC - с этим смартфоном владелец получает только лучшее.

Камеры, останавливающие мгновения
В распоряжении гаджета пять светосильных оптических матриц, разделенных на два модуля:

48Мп (f/1.78), 8Мп, 48Мп (f/2.2) и 5Мп в тыльном;
16Мп во фронтальном.

Камеры отличаются высокой скоростью срабатывания, качественным распознаванием светотеневых переходов, точной детализацией, быстрой работой автофокуса. Имеющиеся достоинства подчеркиваются прогрессивным программным обеспечением, которое предоставляет множество режимов, эффектов и дополнительных инструментов.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телефоны и гаджеты"]
                            },
                                
                            new Catalog_Entity {
                                Name = "Xiaomi Redmi Note 9 4/128GB Grey",
                                Articul = "0001-0004",
                                Price = 40990,
                                Short_Desc = "Xiaomi",
                                Long_Desc = 
@"Обычный Redmi Note 9 внешне оказался очень похож на Redmi Note 9 Pro, но есть как минимум два важных отличия — корпус новинки выполнен из пластика, а под модулем камеры разместился привычный сканер отпечатков пальцев. Спереди же смартфон можно отличить по смещённому в левый угол экрана отверстию фронтальной камеры.

Дисплей у Redmi Note 9 имеет IPS-матрицу с диагональю 6,53 дюйма и разрешение Full HD+. За производительность отвечает процессор MediaTek Helio G85 с 3 или 4 ГБ оперативной и 64 или 128 ГБ встроенной памяти. Слот для карт microSD присутствует.

Основная камера включает в себя сенсоры на 48, 8, 2 и 2 Мп. Есть электронная стабилизация изображения, макро-режим и съёмка с широким углом захвата (118°). Фронтальная камера имеет разрешение 13 Мп.

Аккумулятор обладает ёмкостью 5 020 мА·ч и поддерживает быструю зарядку на 18 Вт через порт USB-C. В комплекте идёт адаптер питания с мощностью 22,5 Вт. Среди прочего: ИК - передатчик для управления бытовой техникой и разъём 3,5 мм для проводных наушников.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телефоны и гаджеты"]
                            },

                            new Catalog_Entity {
                                Name = "Apple iPhone XR 64GB Black",
                                Articul = "0001-0005",
                                Price = 40990,
                                Short_Desc = "Apple",
                                Long_Desc = 
@"Дисплей Liquid Retina HD
ЖК‑дисплей Multi‑Touch с технологией IPS, на всю переднюю панель, диагональ 6,1 дюйма
1792×828 пикселей, 326 пикселей на дюйм
Контрастность 1400:1(стандартная)
Технология True Tone
Широкий цветовой охват(P3)
Тактильный отклик при нажатии
Яркость до 625 кд / м² (стандартная)
  Олеофобное покрытие, устойчивое к появлению следов от пальцев
Поддержка одновременного отображения нескольких языков и наборов символов",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телефоны и гаджеты"]
                            },
                            #endregion

                            #region Телевизоры и аудио

                            new Catalog_Entity{
                                Name = "Samsung UE32T4510AUXRU",
                                Articul = "0002-0001",
                                Price = 17990,
                                Long_Desc = 
@"Общие данные:
Габариты (без подставки): 43,8х73,74х7,41 см
Габариты (с подставкой): 46,54х73,74х15,05 см
Диагональ: 32`
Разрешение: 1366x768
Разъемы(вход): компонентный, антенный, HDMIх2, USB, Ethernet, Wi - fi
Разъемы(выход): оптический

Изображение:
Тип подсветки: LED(Светодиодный)
Процессор изображения: HyperReal
Технология Motion Rate(для повышения четкости передачи движения): 50
Расчетный показатель качества изображения PQI(Picture Quality Index): 900
HDR - High Dynamic Range(Расширенный динамический диапазон)
Динамическая контрастность: Поддержка технологии Mega Contrast(позволяет воспроизводить самые тонкие нюансы контрастов)
Расширение диапазона передачи цветовых оттенков PurColor
Функция Contrast Enhancer
Технология Micro Dimming(локальное затемнение фрагметов экрана для улучшения контрастности)
Режим Кино
Поддержка режима Natural Mode(Естественная передача цвета)

Системы вещания:
Цифровое телевещание(Digital Broadcasting): DVB - T2 / C / S2
Аналоговый тюнер
Разъем для карточки CI(Common Interface): CI + (1.4)
Передача данных(Data Broadcasting): HbbTV 1.5(RU)
Поддержка TV Key

Звук:
Поддержка технологии Multiroom Link(для прослушивания звука в других помещениях)
Поддержка технологии Dolby Digital Plus
Выходная мощность звука: 10 Вт
Тип динамиков: 2 канала

Smart Tv:
                    ОС Tizen
Поддержка приложения Интернет вещей(SmartThings App Support)
Веб - браузер
Галерея
Отображение экрана мобильного устр - ва на экране ТВ - Зеркалирование
Remote Access
Wi - Fi Direct
  Встроенная поддержка беспроводной сети(WiFi4)

Особенности:
                    Технология Digital Clean View
Технология Ultra Clean View
Автопоиск каналов
Автовыключение
Поддержка титров(субтитров)
Технология Connect Share(жесткий диск)
ConnectShare(USB 2.0)
Электронный гид по программам EPG
Поддержка USB HID
Поддержка IPv6
Режим Игры
Телетекст

Дополнительная информация:
                    Eco датчик
Поддержка настенного кронштейна Vesa Wall Mount

Вес: 4 кг без подставки, 4,1 кг с подставкой",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телевизоры и аудио"]
                            },

                            new Catalog_Entity{
                                Name = "Novex NWX-24H121WSG",
                                Articul = "0002-0002",
                                Price = 7990,
                                Long_Desc =
@"В данном устройстве воплощены лучшие достижения и опыт разработчиков в попытке создания телевизора, идеального с точки зрения соотношения цены и качества. Стильный дизайн, специальные возможности по управлению звуком и видео, энергосберегающие технологии, USB-интерфейс с поддержкой распространенных видео-форматов – все эти особенности помогут Вам наслаждаться просмотром фильмов и телепрограмм.

Жидкокристаллическая панель диагональю в 26 дюймов с точки зрения дизайна (линия Hairline) является универсальной, отличаясь лаконичностью и простотой: независимо от стиля Вашего интерьера, телевизор прекрасно его дополнит.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телевизоры и аудио"]
                            },

                            new Catalog_Entity{
                                Name = "Проигрыватель виниловых дисков Sony PS-LX310BT",
                                Articul = "0002-0003",
                                Price = 22990,
                                Long_Desc =
@"Проигрыватель Sony PS-LX310BT адресован меломанам и умело сочетает в себе современные технологии и высокие стандарты воспроизведения эпохи расцвета грампластинок. Позвольте себе насладиться особым звучанием виниловых пластинок и окунуться в мир любимых композиций в чистом и естественном исполнении!

ДЛЯ ЛЮБЫХ ЖАНРОВ
Алюминиевый тонарм со специально разработанной конструкцией плавно движется по поверхности пластинки, извлекая из неё насыщенный и чёткий звук с густыми басами. Ременной привод с лёгким и прочным металлическим литым диском обеспечивает стабильное вращение без случайных смещений.

УДОБНОЕ РЕШЕНИЕ
В девайсе есть функция автоматического воспроизведения аудио, благодаря которой система сама опускает тонарм на пластинку, а вы можете удобно устроиться в кресле рядом. Встроенный Bluetooth-модуль позволяет направить звук в наушники или колонки по беспроводному соединению и слушать музыку в любом уголке дома.

КАК БОЛЬШЕ НРАВИТСЯ
Для тех, кто ностальгирует по классике, на корпусе прибора расположен адаптер для перехода на частоту вращения 45 оборотов в минуту. Кроме того, вы сможете самостоятельно установить нужный уровень усиления звука с помощью соответствующего переключателя позиций.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Телевизоры и аудио"]
                            },

#endregion

                            #region Ноутбуки и компьютеры

                            new Catalog_Entity{
                                Name = "Apple MacBook Pro 13 Mid 2020",
                                Articul = "0003-0001",
                                Price = 124990,
                                Long_Desc =
@"Apple MacBook Pro – стильный, тонкий, лёгкий ноутбук, который удобно брать с собой в поездки. Его возможностей достаточно для плодотворной работы и разнообразных развлечений.

ВЫСОКАЯ ПРОИЗВОДИТЕЛЬНОСТЬ
Благодаря мощному процессору, солидному объёму оперативной памяти, быстрому накопителю SSD, функции ускорения Turbo Boost ноутбук эффективно справляется практически с любыми задачами, в том числе в многозадачном режиме.

РЕАЛИСТИЧНОЕ ИЗОБРАЖЕНИЕ
Ноутбук оснащён экраном, выполненным по технологии Retina: на нём нельзя рассмотреть невооружённым взглядом отдельные точки. Повышенная яркость LED-подсветки и улучшенная контрастность позволили добиться более глубоких чёрных и более ярких белых цветов.

МОЩНЫЙ ЗВУК
В этой модели используется аудиосистема с расширенным звуковым диапазоном и увеличенной громкостью динамиков. Она подключена напрямую к каналу электропитания, что дало возможность значительно усилить её мощность.

УДОБНЫЙ УНИВЕРСАЛЬНЫЙ ИНТЕРФЕЙС
Для зарядки аккумулятора и подключения внешних устройств используется интерфейс Thunderbolt. Это универсальный порт с высокой пропускной способностью.

НОВЫЙ СПОСОБ УПРАВЛЕНИЯ
Там, где у ноутбуков обычно расположены функциональные клавиши, у Apple MacBook Pro находится сенсорная панель Touch Bar. В зависимости от того, чем вы занимаетесь, на ней автоматически отображаются определённые инструменты: регуляторы громкости и яркости, функции управления фото и видео и так далее.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Ноутбуки и компьютеры"]
                            },

                            new Catalog_Entity{
                                Name = "Microsoft Surface Laptop 3 13.5",
                                Articul = "0003-0002",
                                Price = 105990,
                                Long_Desc =
@"Претворите все свои идеи в жизнь с новым ноутбуком Surface Laptop 3, воплотившим в себе все последние инновации Microsoft. Новое поколение обзавелось более мощным процессором, увеличенным тачпадом и выносливым аккумулятором и при этом не потеряло в весе.

Увеличенный на 20% тачбар способствует более комфортной навигации, а отзывчивая клавиатура с подсветкой обеспечит удобство и высокую скорость печати.

Laptop 3 позволяет заменить встроенный SSD-накопитель на любой другой, таким образом увеличив объём памяти вплоть до 1 терабайта.

Surface Laptop 3 обладает мощной батареей, обеспечивающей до 11.5 часов работы без необходимости обращаться к зарядке. Однако даже если Laptop 3 необходимо быстро подзарядить, то функция быстрой зарядки восстановит 80% аккумулятора всего за час.

Ноутбук обзавёлся портом USB Type-С, благодаря которому Laptop 3 можно с лёгкостью синхронизировать с самыми современными устройствами. Помимо USB Type-С ноутбук обладает привычным USB Type-A, аудиоразъемом 3,5-мм, а также портом Surface Connect.

В операционную систему Windows 10 встроена голосовая помощница Cortana, которая позволит сэкономить время и мгновенно найти ответы на все интересующие вопросы. Браузер Microsoft Edge обеспечит быструю навигацию в Интернете.

Windows Hello обеспечит безопасный и быстрый вход в операционную систему за счёт технологии биометрического распознавания лица, избавив вас от запоминания длинных паролей и вероятности ошибки. Всего лишь один взгляд в камеру ноутбука — и вот вы уже внутри. А главное, никто кроме вас не получит доступ к Surface Laptop.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Ноутбуки и компьютеры"]
                            },

                            new Catalog_Entity{
                                Name = "Xiaomi RedmiBook Air 13.3",
                                Articul = "0003-0003",
                                Price = 68990,
                                Long_Desc =
@"Ноутбук RedmiBook Air 13 оснащен широким 13,3-дюймовым экраном, который отображает картинку высокого качества 2,5К (2560 х 1600). Компактный корпус содержит в себе 4-ядерный процессор Intel Core 10-го поколения, жесткий диск емкостью 512 Гб, а также мощную систему охлаждения.

Высокоэффективная система охлаждения
RedmiBook Air 13 имеет мощную систему охлаждения. 1 вентилятор и 2 воздухозаборных отверстия снижают температуру нижней поверхности корпуса на 15,5 %, поэтому гаджет сохраняет необходимую прохладу для эффективного функционирования. Коэффициент теплоотдачи увеличен на 87 %.

Выбор режима производительности
3 режима производительности, которые предоставляются на выбор пользователю, позволяют использовать ноутбук в нужном режиме. Например, осуществление офисной работы, удовлетворение творческих потребностей или долгая автономная работа в бесшумном режиме. Все режимы переключаются между собой всего одним сочетанием клавиш – Fn+K.

Поддержка Wi-Fi 6, Modern Standby и DTS
Устройство работает при использовании сети Wi-Fi 6. По сравнению с предыдущим поколением скорость увеличена в 2,7 раза, что позволяет быстро скачивать большие объемы данных. Функция Modern Standby мгновенно заблокирует ноутбук в случае Вашего ухода и наоборот – разблокирует при малейшем взаимодействии. Так же поддерживается технология стереозвука DTS.

11,5 ч автономной работы
Благодаря встроенному аккумулятору (41 Вт*ч) ноутбук может проработать 11,5 часов в автономном режиме. Предусмотрена быстрая зарядка до 50 % всего за 35 минут. Мини-адаптер Type-C (100 г) отлично помещается в сумке, а также поможет зарядить смартфон.

2 порта USB-C
В боковой части корпуса расположены 2 порта UCB-C и стандартный разъем для наушников (3,5 мм). Обеспечивается быстрый доступ к другим гаджетам и гарнитуре.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Ноутбуки и компьютеры"]
                            },

#endregion

                            #region Техника для кухни

                            new Catalog_Entity{
                                Name = "Кофемашина Melitta Caffeo Avanza F270-100",
                                Articul = "0004-0001",
                                Price = 445990,
                                Long_Desc =
@"Кофемашина Melitta Cafeo Avanza F270-100 использует для заваривания зернового кофе. Имеет встроенную кофемолку с 5 степенями помола. Материал изготовления — нержавеющая сталь и пластик титанового цвета. Машина подогревает молоко и отлично готовит напитки типа капучино. Вы сможете приготовить множество напитков и даже придумать свой рецепт, а машина сохранит его в своей памяти.

Кофемашина Melitta Cafeo Avanza F270-100 просто находка для корпоративных клиентов. Она быстро варит кофе, работает бесшумно, оповещает о степени готовности. Можно задать объем и крепость напитка. Надежность эксплуатации гарантирована европейскими стандартами качества. Это отличное приобретение для вашего офиса на радость всех его сотрудников.",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Техника для кухни"]
                            },

                            new Catalog_Entity{
                                Name = "Microsoft Surface Laptop 3 13.5",
                                Articul = "0004-0002",
                                Price = 105990,
                                Long_Desc =
@"",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Техника для кухни"]
                            },

                            new Catalog_Entity{
                                Name = "Xiaomi RedmiBook Air 13.3",
                                Articul = "0004-0003",
                                Price = 68990,
                                Long_Desc =
@"",
                                Awailable = true,
                                InStock = 10,
                                Category = _categories["Техника для кухни"]
                            }

#endregion
                        };


                    foreach (var ent in entities)
                        _entities.Add(ent.Articul, ent);

                    return _entities;
                 }
                return _entities;
            }   
        }

        public static Image[] Images { 
            get { 
                if(_images == null){
                    var images = new List<Image>{

                        #region Phones

                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\iPhone\12\1.jpg",
                            Entity = _entities["0001-0001"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\iPhone\12\2.jpg",
                            Entity = _entities["0001-0001"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\iPhone\12\3.jpg",
                            Entity = _entities["0001-0001"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\iPhone\XR\1.jpg",
                            Entity = _entities["0001-0005"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\iPhone\XR\2.jpg",
                            Entity = _entities["0001-0005"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\iPhone\XR\3.jpg",
                            Entity = _entities["0001-0005"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\OnePlus\8Pro\1.jpg",
                            Entity = _entities[@"0001-0003"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\OnePlus\8Pro\2.jpg",
                            Entity = _entities[@"0001-0003"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\OnePlus\8Pro\3.jpg",
                            Entity = _entities[@"0001-0003"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\Xiaomi\Mi10T\1.jpg",
                            Entity = _entities[@"0001-0002"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\Xiaomi\Mi10T\2.png",
                            Entity = _entities[@"0001-0002"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\Xiaomi\RedmiNote9\1.jpg",
                            Entity = _entities[@"0001-0004"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\Xiaomi\RedmiNote9\2.jpg",
                            Entity = _entities[@"0001-0004"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Phones&Gadgets\Xiaomi\RedmiNote9\3.jpg",
                            Entity = _entities[@"0001-0004"]
                        }
                        #endregion

                        #region TV&Audio

                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Samsumg\UE5\1.jpg",
                            Entity = _entities["0002-0001"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Samsumg\UE5\2.jpg",
                            Entity = _entities["0002-0001"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Samsumg\UE5\3.jpg",
                            Entity = _entities["0002-0001"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Novex\1.jpg",
                            Entity = _entities["0002-0002"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Novex\2.jpg",
                            Entity = _entities["0002-0002"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Novex\3.jpg",
                            Entity = _entities["0002-0002"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Sony\1.jpg",
                            Entity = _entities[@"0002-0003"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Sony\2.jpg",
                            Entity = _entities[@"0002-0003"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Sony\3.jpg",
                            Entity = _entities[@"0002-0003"]
                        },

                        #endregion

                        #region Notebook&Desk

                        new Image
                        {
                            Patch = @"\IMG\Nodebook&Desck\Apple\1.jpg",
                            Entity = _entities["0003-0001"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Nodebook&Desck\Apple\2.jpg",
                            Entity = _entities["0003-0001"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\Nodebook&Desck\Apple\3.jpg",
                            Entity = _entities["0003-0001"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Microsoft\1.png",
                            Entity = _entities["0003-0002"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Microsoft\2.png",
                            Entity = _entities["0003-0002"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Microsoft\3.png",
                            Entity = _entities["0003-0002"]
                        },

                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Xiaomi\1.png",
                            Entity = _entities[@"0003-0003"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Xiaomi\2.png",
                            Entity = _entities[@"0003-0003"]
                        },
                        new Image
                        {
                            Patch = @"\IMG\TV&Audio\Xiaomi\3.png",
                            Entity = _entities[@"0003-0003"]
                        },

#endregion

                    };
                    images.CopyTo(_images);
                    return _images;
                }
                return _images;
            } 
        }

        public static Dictionary<Catalog_Attribute, Catalog_Value> AttrValuePairs{ 
            get{
                if(_attrValuePairs == null){
                    var attrValuePairs = new Dictionary<Catalog_Attribute, Catalog_Value>();

                    #region iPhone 12
                    var values = new Catalog_Value[] {
                        new Catalog_Value{
                            IntegerValue = 64
                        },
                        new Catalog_Value{
                            StringValue = "2G, 3G, LTE"
                        },
                        new Catalog_Value{
                            IntegerValue = 1
                        },
                        new Catalog_Value{
                            StringValue = "6.1`"
                        },
                        new Catalog_Value{
                            StringValue = "2532x1170"
                        },
                        new Catalog_Value{
                            IntegerValue = 12
                        },
                        new Catalog_Value{
                            IntegerValue = 12
                        },
                        new Catalog_Value{
                            StringValue = "Apple A14 Bionic"
                        }
                    };

                    var attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Встроенная память, Гб",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Стандарты связи",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Количество SIM-карт",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Диагональ экрана, дюймов",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Разрешение экрана",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Разрешение основной камеры, Мп",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Разрешение фронтальной камеры, Мп",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0001"],
                            AttributeName = "Процессор",
                            Value = values[7]
                        }

                        
                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region iPhone XR
                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            IntegerValue = 64
                        },
                        new Catalog_Value{
                            StringValue = "2G, 3G, LTE"
                        },
                        new Catalog_Value{
                            IntegerValue = 1
                        },
                        new Catalog_Value{
                            StringValue = "6.7`"
                        },
                        new Catalog_Value{
                            StringValue = "2532x1170"
                        },
                        new Catalog_Value{
                            IntegerValue = 12
                        },
                        new Catalog_Value{
                            IntegerValue = 12
                        },
                        new Catalog_Value{
                            StringValue = "Apple A14 Bionic"
                        }
                    };

                     attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Встроенная память, Гб",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Стандарты связи",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Количество SIM-карт",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Диагональ экрана, дюймов",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Разрешение экрана",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Разрешение основной камеры, Мп",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Разрешение фронтальной камеры, Мп",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0005"],
                            AttributeName = "Процессор",
                            Value = values[7]
                        }


                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region Mi 10 T

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            IntegerValue = 8
                        },
                        new Catalog_Value{
                            IntegerValue = 128
                        },
                        new Catalog_Value{
                            IntegerValue = 1
                        },
                        new Catalog_Value{
                            StringValue = "6.67`"
                        },
                        new Catalog_Value{
                            StringValue = "2400x1080"
                        },
                        new Catalog_Value{
                            IntegerValue = 64
                        },
                        new Catalog_Value{
                            IntegerValue = 20
                        },
                        new Catalog_Value{
                            StringValue = "Qualcomm Snapdragon 865"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Оперативная память, Гб",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Встроенная память",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Количество SIM-карт",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Диагональ экрана, дюймов",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Разрешение экрана",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Разрешение основной камеры, Мп",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Разрешение фронтальной камеры, Мп",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0002"],
                            AttributeName = "Процессор",
                            Value = values[7]
                        }


                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region OnePlus 8 Pro 

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            IntegerValue = 12
                        },
                        new Catalog_Value{
                            IntegerValue = 256
                        },
                        new Catalog_Value{
                            IntegerValue = 2
                        },
                        new Catalog_Value{
                            StringValue = "6.78`"
                        },
                        new Catalog_Value{
                            StringValue = "3168x1440"
                        },
                        new Catalog_Value{
                            IntegerValue = 48
                        },
                        new Catalog_Value{
                            IntegerValue = 16
                        },
                        new Catalog_Value{
                            StringValue = "Qualcomm Snapdragon 685"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Оперативная память, Гб",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Встроенная память",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Количество SIM-карт",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Диагональ экрана, дюймов",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Разрешение экрана",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Разрешение основной камеры, Мп",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Разрешение фронтальной камеры, Мп",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0003"],
                            AttributeName = "Процессор",
                            Value = values[7]
                        }


                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    # region Redmi Note 9

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            IntegerValue = 4
                        },
                        new Catalog_Value{
                            IntegerValue = 128
                        },
                        new Catalog_Value{
                            IntegerValue = 2
                        },
                        new Catalog_Value{
                            StringValue = "6.53`"
                        },
                        new Catalog_Value{
                            StringValue = "2340x1080"
                        },
                        new Catalog_Value{
                            IntegerValue = 48
                        },
                        new Catalog_Value{
                            IntegerValue = 13
                        },
                        new Catalog_Value{
                            StringValue = "MediaTek Helio G85"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Оперативная память, Гб",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Встроенная память",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Количество SIM-карт",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Диагональ экрана, дюймов",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Разрешение экрана",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Разрешение основной камеры, Мп",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Разрешение фронтальной камеры, Мп",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0001-0004"],
                            AttributeName = "Процессор",
                            Value = values[7]
                        }
                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region Samsung UE50TU7170U

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            StringValue = "50`"
                        },
                        new Catalog_Value{
                            StringValue = "127"
                        },
                        new Catalog_Value{
                            StringValue = "60 Гц"
                        },
                        new Catalog_Value{
                            StringValue = "Тёмно-Серый"
                        },
                        new Catalog_Value{
                            StringValue = "24.9 см"
                        },
                        new Catalog_Value{
                            StringValue = "75.3 см"
                        },
                        new Catalog_Value{
                            StringValue = "111.6 см"
                        },
                        new Catalog_Value{
                            StringValue = "11.6 кг"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Диагональ",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Диагональ экрана",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Частота обновления",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Цвет",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Глубина",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Высота",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Ширина",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0001"],
                            AttributeName = "Вес",
                            Value = values[7]
                        }


                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);
                    #endregion

                    #region Novex NWX-24H121WSG

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            StringValue = "24`"
                        },
                        new Catalog_Value{
                            StringValue = "61"
                        },
                        new Catalog_Value{
                            StringValue = "50 Гц"
                        },
                        new Catalog_Value{
                            StringValue = "Королевский-белый"
                        },
                        new Catalog_Value{
                            StringValue = "15.1 см"
                        },
                        new Catalog_Value{
                            StringValue = "36.6 см"
                        },
                        new Catalog_Value{
                            StringValue = "55.2 см"
                        },
                        new Catalog_Value{
                            StringValue = "2.5 кг"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Диагональ",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Диагональ экрана",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Частота обновления",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Цвет",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Глубина",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Высота",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Ширина",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0002"],
                            AttributeName = "Вес",
                            Value = values[7]
                        }

                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region Sony PS-LX310BT

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            StringValue = "В комплекте"
                        },
                        new Catalog_Value{
                            StringValue = "Алмазная"
                        },
                        new Catalog_Value{
                            StringValue = "3.5 г"
                        },
                        new Catalog_Value{
                            StringValue = "Пластик"
                        },
                        new Catalog_Value{
                            StringValue = "Аллюминий"
                        },
                        new Catalog_Value{
                            StringValue = "1.8 Вт"
                        },
                        new Catalog_Value{
                            StringValue = "110*430*370 мм"
                        },
                        new Catalog_Value{
                            StringValue = "3.5 кг"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Звукосниматель",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Материал иглы звукоснимателя",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Макс. давление иглы",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Материал корпуса",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Материал диска",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Потребляемая мощность",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Габаритные размеры (В*Ш*Г)",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0002-0003"],
                            AttributeName = "Вес",
                            Value = values[7]
                        }

                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region Apple MakBook Pro 

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            StringValue = "13.3`"
                        },
                        new Catalog_Value{
                            StringValue = "Intel"
                        },
                        new Catalog_Value{
                            IntegerValue = 8
                        },
                        new Catalog_Value{
                            StringValue = "DDR3"
                        },
                        new Catalog_Value{
                            StringValue = "Встроенный"
                        },
                        new Catalog_Value{
                            StringValue = "SSD"
                        },
                        new Catalog_Value{
                            StringValue = "SSD 512Гб"
                        },
                        new Catalog_Value{
                            StringValue = "1.4 кг"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Диагональ экрана",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Производитель процессора",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Объем оперативной памяти, Гб",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Тип оперативной памяти",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Графический контроллер",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Тип накопителя",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Объем памяти",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0001"],
                            AttributeName = "Вес",
                            Value = values[7]
                        }

                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region Microsoft Surface

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            StringValue = "13.5`"
                        },
                        new Catalog_Value{
                            StringValue = "Intel"
                        },
                        new Catalog_Value{
                            IntegerValue = 8
                        },
                        new Catalog_Value{
                            StringValue = "DDR4"
                        },
                        new Catalog_Value{
                            StringValue = "Встроенный"
                        },
                        new Catalog_Value{
                            StringValue = "SSD"
                        },
                        new Catalog_Value{
                            StringValue = "SSD 256Гб"
                        },
                        new Catalog_Value{
                            StringValue = "1.29 кг"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Диагональ экрана",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Производитель процессора",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Объем оперативной памяти, Гб",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Тип оперативной памяти",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Графический контроллер",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Тип накопителя",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Объем памяти",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0002"],
                            AttributeName = "Вес",
                            Value = values[7]
                        }

                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion

                    #region Xiaomi RedmiBook Air 13.3

                    values = new Catalog_Value[] {
                        new Catalog_Value{
                            StringValue = "13.3`"
                        },
                        new Catalog_Value{
                            StringValue = "Intel"
                        },
                        new Catalog_Value{
                            IntegerValue = 16
                        },
                        new Catalog_Value{
                            StringValue = "LPDDR3"
                        },
                        new Catalog_Value{
                            StringValue = "Встроенный"
                        },
                        new Catalog_Value{
                            StringValue = "SSD"
                        },
                        new Catalog_Value{
                            StringValue = "SSD 512Гб"
                        },
                        new Catalog_Value{
                            StringValue = "1.05 кг"
                        }
                    };

                    attr = new List<Catalog_Attribute>{
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Диагональ экрана",
                            Value = values[0]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Производитель процессора",
                            Value = values[1]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Объем оперативной памяти, Гб",
                            Value = values[2]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Тип оперативной памяти",
                            Value = values[3]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Графический контроллер",
                            Value = values[4]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Тип накопителя",
                            Value = values[5]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Объем памяти",
                            Value = values[6]
                        },
                        new Catalog_Attribute {
                            Entity = _entities["0003-0003"],
                            AttributeName = "Вес",
                            Value = values[7]
                        }

                    };

                    for (int i = 0; i < attr.Count; i++)
                        _attrValuePairs.Add(attr[i], values[i]);


                    #endregion


                    _attrValuePairs = attrValuePairs;
                    return _attrValuePairs;
                }
                return _attrValuePairs;
            }
        }
    }
}
