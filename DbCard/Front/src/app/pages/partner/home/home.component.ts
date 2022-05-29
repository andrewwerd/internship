import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { Filial } from "src/app/_models/filial/filial";
import { News } from "src/app/_models/news/news";
import { FilialDialog } from "./filial-dialog/filial-dialog.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  newsArray: News[] = [
    {
      title: 'Новый продукт: Макароны «Шебекинские»',
      body: 'Макароны «Шебекинские» - качественная продукция, выполненная из муки пшеницы грубого помола и максимально приближенная к итальянской пасте. Широтой ассортимента и качеством макарон марка удовлетворяет все потребительные нужды. Продукция создается по лучшим образцам макаронной промышленности с использованием опыта итальянских производителей, а также с применением итальянского оборудования. Покупайте качественные макароны по доступным ценам в сети супермаркетов Nr1!'
    },
    {
      title: 'Nr1 по адресу: ул. Пушкин 32, снова открыл свои двери для старых и новых друзей !',
      body: 'Добрый день Уважаемые клиенты сети супермаркетов Nr1! Хотим Вам сообщить приятную, предновогоднюю новость: Полюбившийся многим жителям Кишинёва наш магазин расположенный по адресу: ул.Пушкин 32(торговый центр: "Sun city"), снова открыл свои двери для старых и новых друзей! Приглашаем посетить наш обновленный магазин и желаем Вам приятных праздников и покупок! Ваша сеть супермаркетов Nr1!'
    },
    {
      title: 'Открытие нового магазина по адресу Московский пр-т, 9/5',
      body: 'Дорогие друзья! Cупермаркет «Nr1» спешит поделиться с Вами радостными новостями! Сеть "Nr1" открыла новый супермаркет по адресу Московский пр-т, 9/5. Это 17-й магазин сети "Nr1". При строительстве этого магазина мы использовали современные технологии, которые экономят электричество и газ. Все освещение магазина, включая освещение холодильных витрин - энергосберегающие LED лампы. А тепло, которое вырабатывают холодильники, мы используем для отопления и подогрева воды. Благодаря такой экономии "Nr1" продолжает сдерживать рост цен.'
    }
  ];

  newsForm: FormGroup | undefined;

  submitted = false;
  filialColumns: string[] = ['region', 'city', 'street', 'houseNumber', 'phoneNumber'];
  filials: Filial[] = [
    {
      phoneNumber: '100000007',
      region: 'Кишинев',
      houseNumber: '47/7',
      city: 'Кишинев',
      street: 'Дачия'
    },
    {
      phoneNumber: '100000006',
      region: 'Кишинев',
      houseNumber: '23',
      city: 'Кишинев',
      street: 'Тестимицану'
    },
    {
      phoneNumber: '100000005',
      region: 'Кишинев',
      houseNumber: '55',
      city: 'Кишинев',
      street: 'А. Щусев'
    },
    {
      phoneNumber: '100000004',
      region: 'Кишинев',
      houseNumber: '15',
      city: 'Кишинев',
      street: 'Алеку Руссо'
    },
    {
      phoneNumber: '100000003',
      region: 'Кишинев',
      houseNumber: '7',
      city: 'Кишинев',
      street: 'Зелински'
    },
    {
      phoneNumber: '100000002',
      region: 'Кишинев',
      houseNumber: '24/1',
      city: 'Кишинев',
      street: 'Лев Толстой'
    },
    {
      phoneNumber: '100000001',
      region: 'Кишинев',
      houseNumber: '139',
      city: 'Кишинев',
      street: 'Дечебал'
    },
    {
      phoneNumber: '100000000',
      region: 'Кишинев',
      houseNumber: '9/5',
      city: 'Кишинев',
      street: 'Московский пр-т'
    }]

  constructor(private formBuilder: FormBuilder,
    public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.newsForm = this.formBuilder.group({
      title: ['', [Validators.required]],
      body: ['', [Validators.required]]
    });
  }

  get title() {
    return this.newsForm?.get('title');
  }

  get body() {
    return this.newsForm?.get('body');
  }

  onSubmit() {
    this.newsArray.unshift({ ...this.newsForm?.value });
    this.newsForm?.reset()
  }

  onReset() {
    this.newsForm?.reset();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(FilialDialog, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe((result: Filial) => {
      console.log(result);
      this.filials.unshift(result)
      console.log(this.filials);
    });
  }
} 