# CrossplatformLabs
# Варіант 14
# ЛР 1
Нехай х – натуральне число. Назвемо у його дільником, якщо 1 ≤ у ≤ х і залишок від ділення х на у дорівнює нулю.
Вказано число х. Знайдіть кількість його дільників.
## Вхідні дані
Вхідний файл INPUT.TXT містить задане число x (1 ≤ x ≤ 10^18). Всі найпростіші дільники числа x не перевищують 1000.
## Вихідні дані
У вихідний файл OUTPUT.TXT виведіть відповідь на завдання.
## Приклади
| №  | INPUT.TXT        | OUTPUT.TXT  |
|----|------------------|-------------|
| 1  | 12               | 6           |
| 2  | 239              | 2           |

# ЛР 2
На прямій гілці залізниці розташовано кілька станцій. Вказано вартість проїзду між будь-якими двома станціями.
Потрібно написати програму знаходження мінімальної вартості проїзду між крайніми станціями. Рухатися залізницею можна тільки в одному напрямку (від станції з меншим номером до станції з великим номером).
## Вхідні дані
Вхідний файл INPUT.TXT містить у першому рядку натуральне число N, не більше 250. Усього на дорозі розташовано N+1 станцій, пронумерованих від 0 до N. У наступних рядках записано N(N+1)/2 чисел, що задають вартості проїзду між станціями: спочатку вартість проїзду від станції 0 до станцій 1, 2, 3, …, N, потім від станції 1 до станцій 2, 3, …, N, …, від станції N-1 до станції N. Усі вартості проїзду – невід'ємні цілі числа, що не перевищують 10000.
## Вихідні дані
Вихідний файл OUTPUT.TXT повинен містити одне число – мінімальну вартість проїзду від станції 0 до станції N із можливими пересадками.
## Приклади
| №  | INPUT.TXT        | OUTPUT.TXT  |
|----|------------------|-------------|
| 1  | 3                | 12          |
|    | 7 10 20          |             |
|    | 4 8              |             |
|    | 2                |             |

У наведеному прикладі всього 4 станції з номерами 0, 1, 2, 3. Оптимальний маршрут проходить через станції 0, 2 та 3. Його вартість дорівнює 10+2=12.

# ЛР 3
Уявіть, що ви перебуваєте на службі у зовнішній розвідці Міжгалактичного Альянсу Республіканських Сил (МАРС). Одному з агентів розвідки не пощастило, і він був захоплений на засекреченій космічній базі. На щастя, зовнішню розвідку МАРС вдалося роздобути план цієї бази. І тепер вам доручено розробити план втечі.
База є прямокутником розміром NхM, з усіх боків оточений стінами, і складається з квадратних відсіків одиничної площі. База має K виходи, до одного з яких агенту необхідно дістатися. У деяких відсіках бази є стіни. Ваш агент може переміщатися з відсіку в будь-який із чотирьох сусідніх з ним, якщо в тому відсіку, куди він хоче переміститися, немає стіни.
Крім того, база забезпечена системою гіпертунелів, здатних переміщати агента з одного відсіку бази (вхід до гіпертунелю) до іншого (вихід з гіпертунелю). Коли агент знаходиться у відсіку, де є вхід до гіпертунелю, він може (але не зобов'язаний) ним скористатися.
Початкове становище вашого агента відоме. Вам необхідно знайти найкоротший шлях втечі (тобто шлях через мінімальну кількість відсіків).
## Вхідні дані
У першому рядку вхідного файлу INPUT.TXT записані числа N і M (2 ≤ N ≤ 100, 2 ≤ M ≤ 100), що задають розміри бази: N — кількість рядків у плані бази, M — кількість стовпців. У другому рядку записані початкові координати агента XA,YA (1 ≤ XA ≤ N, 1 ≤ YA ≤ M). Перша координата задає номер рядка, друга - номер стовпця. Рядки нумеруються зверху вниз, стовпці зліва направо. Далі йдуть N рядків по M чисел, що задають опис стінок усередині бази: 1 відповідає стінці, 0 - її відсутності. Далі в окремому рядку записано число H (0 ≤ H ≤ 1000) – кількість гіпертунелів. У наступних H рядках йдуть описи гіпертунелів. Кожен гіпертунель задається 4 числами: X1, Y1, X2, Y2 (1 ≤ X1, X2 ≤ N; 1 ≤ Y1, Y2 ≤ M) - координатами входу та виходу гіпертунелю. Жодні два гіпертунелі не мають загального входу. Після цього в окремому рядку слідує число K (1 ≤ K ≤ 10) — кількість виходів з бази. У наступних K рядках йдуть описи виходів із бази. Кожен вихід задається двома координатами X і Y (1 ≤ X ≤ N; 1 ≤ Y ≤ M).
Гарантується, що початкові координати агента не збігаються з жодним виходом і він не стоїть у відсіку, зайнятому стіною. Жодні входи та виходи гіпертунелів, а також виходи з бази не знаходяться у відсіках, зайнятих стінами. Ніякий вхід до гіпертунелю не збігається з виходом з бази.
## Вихідні дані
Якщо втеча неможлива, виведіть у вихідний файл OUTPUT.TXT "Impossible". В іншому випадку слід вивести кількість відсіків у найкоротшому шляху втечі.
## Приклади
| №  | INPUT.TXT        | OUTPUT.TXT  |
|----|------------------|-------------|
| 1  | 4 5              | 4           |
|    | 2 1              |             |
|    | 0 0 0 0 0        |             |
|    | 0 1 0 0 0        |             |
|    | 0 0 0 0 0        |             |
|    | 0 0 0 0 0        |             |
|    | 2                |             |
|    | 1 2 1 4          |             |
|    | 3 1 1 4          |             |
|    | 1                |             |
|    | 2 4              |             |
