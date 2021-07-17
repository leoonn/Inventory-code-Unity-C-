# Inventory-code-Unity-C-
Fiz um inventario para o jogador usando a Unity 3D em c#

Como esses scripts funcionam?

O jogador ao collidir com um objeto de jogo pode coleta-lo apertando o E , com isso este objeto terá o script pickUp que terá
a imagem do item que será enviada para dentro do inventario do jogador, com a imagem dentro do inventario voce conseguirá selecionar os itens com apenas 
os cliques ou arrasta-los para fora do inventario ocasionando o Drop do item e o spawn do objeto 3D que foi pego inicialmente, fazendo
com que a imagem dentro do inventario seja destruida e liberando um espaço no slot usado.

Para Utilizar este codigo na Unity terá que fazer alguns ajustes que são:

//UnityEditor
Passo 1: Ter um jogador/player, com rigidBody e um collider

Passo 2: Criar prefabs dos itens que serao coletados em cena de jogo neles deverá ter um component de colisao e acionado o trigger

Passo 3: Criar UI dos itens que serão adicionados em cena de jogo, terá que ter como component um botao

Passo 4: Criar um canvas e dentro dele criar um panel que será o inventory UI, dentro do innventory UI um gameObject vazio para guardar apenas as imagens dos slots 
(os slots serão apenas imagens), 
em seguida criará outro gameObject vazio dentro do invUI. Este ultimo GameObject vai guardar os itensUI que serão instanciados dentro do gameobject itens, 
para melhor organização recomendo criar um GRID LAYOUT dentro do gameObject vazio que guardará os itens e configure-o como achar melhor e dependendo de suas necessidades de slots.
Obs: Deve se ter a mesma quantiade de slots para as quantidades de itens configuradas no grid layout

//Codigos
Passo 1: Adicione o codigo inventory ao jogador/Player, atribua no inspector os respectivos objetos da hierarquia no script. Exemplo InventoryUI (o panel criado nos passos acima), 
adicione no slot vazio do inspector do codigo inventory esse objeto. Nao esqueça de adicionar as imagens dos slots ao array slots!

Passo 2: Adicione aos prefabs de objetos que serão coletados pelo jogados, o Script PickUp, adicione os objetos necessario ao inspector do script

Passo 3: Adicione aos prefabs dos itensUI que será instanciado dentro do inventory, o Script de Drag e ItensUI, 
adicione em itens UI o prefab do objeto que foi pego pelo jogador/player

Fazendo todos esses passos o inventory de seu jogador deve funcionar, configure os inputs no script como desejar, por padrao deixei I abre inventario e E pega os itens 

Obs: No script de Inventory tem se algumas referencias/Variaveis que nao necessitam de preenchimento que sao utilizadas apenas para depuração: ItemSelected e o totalItens

//Inglish
# Inventory-code-Unit-C-
I made an inventory for the player using Unity 3D in c#

How do these scripts work?

When the player collides with a game object, he can collect it by pressing the E , with that this object will have the pickUp script that will have
the image of the item that will be sent into the player's inventory, with the image within the inventory you will be able to select the items with only
the clicks or drags them out of the inventory causing the item to drop and the 3D object that was initially caught to spawn, making
causing the image inside the inventory to be destroyed and freeing up space in the used slot.

To use this code in Unity you will have to make some adjustments that are:

//UnitEditor
Step 1: Have a player/player, with rigidBody and a collider

Step 2: Create prefabs of the items that will be collected in the game scene on them must have a collision component and trigger the trigger

Step 3: Create UI of the items that will be added in the game scene, you will have to have a button as component

Step 4: Create a canvas and inside it create a panel that will be the inventory UI, inside the innventory UI an empty gameObject to store only the images of the slots
(slots will be images only),
it will then create another empty gameObject inside the invUI. This last GameObject will store the itemsUI that will be instantiated inside the gameobject items,
for better organization I recommend creating a GRID LAYOUT inside the empty gameObject that will store the items and configure it as you see fit and depending on your slots needs.
Note: You must have the same amount of slots for the quantity of items configured in the layout grid

//Codes
Step 1: Add the inventory code to the player/Player, assign the respective hierarchy objects in the script in the inspector. InventoryUI example (the panel created in the steps above),
add this object to the empty slot of the inventory code inspector. Don't forget to add the slot images to the slots array!

Step 2: Add to the prefabs of objects that will be collected by the player, the Script PickUp, add the necessary objects to the script inspector

Step 3: Add to the prefabs of the itemsUI that will be instantiated into the inventory, the Drag Script and ItemsUI,
add in UI items the prefab of the object that was picked up by the player/player

By doing all these steps your player's inventory should work, configure the inputs in the script as you wish, by default I let I open inventory and E get the items

Note: In the Inventory script there are some references/Variables that do not need filling that are used only for debugging: ItemSelected and totalItens

