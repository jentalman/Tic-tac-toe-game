 Tic-tac-toe-game

Запуск игры осуществляется в GameCore в методе Start. Через Inject ему передается поле GameField через которое работает игра. В нем хранятся настройки для игры,
результаты действий игроков и генерируется игровое поле. Сам класс конечно стоило бы разбить на классы по меньше, но тогда начинались проблемы с разной не явной зависимостью, 
а как это граммотно сделать через Zenject пока не разобрался. При генерации поля, осуществляется подписка на ивент, которые будет срабатывать когда по ячейке будут кликать. 
После срабатывания ивента на ячейке сохраняется результат в массивы по которым затем отслеживается победа. Пример: имеется массив строки, состоящий из N- элементов где
N - это размер игрового поля, если этот массив заполняется, то значит игрок победил. Получилось конечно громоско, потому что на каждого игрока создается по 4 таких массива, на 
момент написания это казался наиболее эффективным вариантом, особенно из тех, которые приходили в голову. 