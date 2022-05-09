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
      body: 'Добрый день Уважаемые клиенты сети супермаркетов Nr1! Хотим Вам сообщить приятную, предновогоднюю новость: Полюбившийся многим жителям Кишинёва наш магазин расположенный по адресу: ул.Пушкин 32(торговый центр: "Sun City"), снова открыл свои двери для старых и новых друзей! Приглашаем посетить наш обновленный магазин и желаем Вам приятных праздников и покупок! Ваша сеть супермаркетов Nr1!'
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
      PhoneNumber: '100000007',
      Region: 'Кишинев',
      HouseNumber: '47/7',
      City: 'Кишинев',
      Street: 'Дачия'
    },
    {
      PhoneNumber: '100000006',
      Region: 'Кишинев',
      HouseNumber: '23',
      City: 'Кишинев',
      Street: 'Тестимицану'
    },
    {
      PhoneNumber: '100000005',
      Region: 'Кишинев',
      HouseNumber: '55',
      City: 'Кишинев',
      Street: 'А. Щусев'
    },
    {
      PhoneNumber: '100000004',
      Region: 'Кишинев',
      HouseNumber: '15',
      City: 'Кишинев',
      Street: 'Алеку Руссо'
    },
    {
      PhoneNumber: '100000003',
      Region: 'Кишинев',
      HouseNumber: '7',
      City: 'Кишинев',
      Street: 'Зелински'
    },
    {
      PhoneNumber: '100000002',
      Region: 'Кишинев',
      HouseNumber: '24/1',
      City: 'Кишинев',
      Street: 'Лев Толстой'
    },
    {
      PhoneNumber: '100000001',
      Region: 'Кишинев',
      HouseNumber: '139',
      City: 'Кишинев',
      Street: 'Дечебал'
    },
    {
      PhoneNumber: '100000000',
      Region: 'Кишинев',
      HouseNumber: '9/5',
      City: 'Кишинев',
      Street: 'Московский пр-т'
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