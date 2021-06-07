
document.querySelector('#sort-asc').onclick = function () {
  mySort('data-price');
}
document.querySelector('#sort-desc').onclick = function () {
  mySortDesc('data-price');
}
document.querySelector('#sort-raiting').onclick = function () {
  mySort('data-raiting');
}
//по возрастанию
function mySort(sortType) {
  //получаем элементы родител€
  let nav = document.querySelector('.goods-wrap');

  for (let i = 0; i < nav.children.length; i++) {
    for (let j = i; j < nav.children.length; j++) {
      //сравниваем элементы по атрибуту, + перед элементом переводит в число
      if (+nav.children[i].getAttribute(sortType) > +nav.children[j].getAttribute(sortType)) {
        //console.log(1);
        //мен€ем местами элементы т.е. перезаписываю первый элемент
        replacedNode = nav.replaceChild(nav.children[j], nav.children[i]);
        //после него вставл€ю тот что перезаписал
        //где replacedNode старый элемент который затерли
        insertAfter(replacedNode, nav.children[i]);
      }
    }
  }
}
//по убыванию
function mySortDesc(sortType) {
  //получаем элементы родител€
  let nav = document.querySelector('.goods-wrap');

  for (let i = 0; i < nav.children.length; i++) {
    for (let j = i; j < nav.children.length; j++) {
      //сравниваем элементы по атрибуту, + перед элементом переводит в число
      if (+nav.children[i].getAttribute(sortType) < +nav.children[j].getAttribute(sortType)) {
        //console.log(1);
        //мен€ем местами элементы т.е. перезаписываю первый элемент
        replacedNode = nav.replaceChild(nav.children[j], nav.children[i]);
        //после него вставл€ю тот что перезаписал
        //где replacedNode старый элемент который затерли
        insertAfter(replacedNode, nav.children[i]);
      }
    }
  }
}
//функци€ получает элемент определ€ет его родителей и вставл€ет перед ним нужное значение
function insertAfter(elem, refElem) {
  return refElem.parentNode.insertBefore(elem, refElem.nextSibling);
}