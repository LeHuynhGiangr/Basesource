import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { AppUsers } from './../../login/shared/login.model';
import { LoginService } from './../../login/shared/login.service';
import { PostService } from 'src/app/_core/services/post.service';

@Component({
    selector: 'app-newsfeed',
    templateUrl: './newsfeed.component.html',
    styleUrls: ['./newsfeed.component.css']
})
export class NewsfeedComponent implements OnInit {
  public m_posts:{
    id:number,
    dateCreated:string,
    content:string,
    imageSource?:string,
    likeJson:{count:number, subjects:{Id:string, Name:string}[]},
    commentJson:{Id:string, Name:string, Comment:string}[],
    authorName:string,
    authorThumb?:string,
    authorId:string
  }[]/*=[
    {
      "id": 7,
      "dateCreated": "2020-11-30T23:07:11.8852426",
      "content": "Travel to Phu Yen – Everything you need to know Phu Yen Overview: Phu Yen is another off beat track destination in Central of Vietnam with pristine beaches, busy fisherman villages, glistening mini desserts, mouth-watering seafood and astounding natural landscapes. If you’re planning to travel to Phu Yen for a peaceful holiday, you certainly won’t be disappointed.",
      "likeJson": {
          "count": 2,
          "subjects": [
              {
                  "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
                  "Name": "Huynh Le"
              },
              {
                  "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
                  "Name": "Dang Bao"
              }
          ]
      },
      "commentJson": [
          {
              "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
              "Name": "Huynh Le",
              "Comment": ":)"
          },
          {
              "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
              "Name": "Dang Bao",
              "Comment": "woow!!!"
          }
      ],
      "authorName": "Bich Hoang",
      "authorThumb":"/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAMDAwMDAwMEBAMFBQQFBQcGBg"+
        "YGBwoHCAcIBwoPCgsKCgsKDw4QDQwNEA4YExERExgcGBYYHCIeHiIrKSs4OEsBAwMDAwMDAwQEAwUFBAUFBwYGBgYHCgcIBw"+
        "gHCg8KCwoKCwoPDhANDA0QDhgTERETGBwYFhgcIh4eIispKzg4S//CABEIAB4AKAMBIgACEQEDEQH/xAAZAAADAQEBAAAAAA"+
        "AAAAAAAAAFBggJBAf/2gAIAQEAAAAAzHJVrJgkuz6FRgrrzNYfBIQj1SlpkWP/xAAWAQEBAQAAAAAAAAAAAAAAAAAFBwL/2g"+
        "AIAQIQAAAA2U45LaV//8QAFwEAAwEAAAAAAAAAAAAAAAAAAAUIAv/aAAgBAxAAAADTlCVNLn//xAAmEAABAwQCAQQDAQAAAA"+
        "AAAAABAgMEAAUREgYxIQcTIlEyQVJh/9oACAEBAAE/AJCm3ntx1jqotifkmNspLXvOobSVnAG6gnY/QHZrnfoJw3h9mD9qvp"+
        "vy2JAYmgRVMFBKcgtLCsqqS0q0XC4R0ZWELW0CRgkDomiyo5+NQYrTJDzqdiOk1arg5DvtjuahlMOdHkBOuwAZcC+j31U/nD"+
        "PLxBj8emzLrGiD3ROmMqSzuBkJT7v5+eyajem99vc+XNu6xHckOLedWoYytZ2VXKOImxJDiHUuM7ahQ7NQW0qLhWj/AGrPZH"+
        "L9cYcGJru8vBJOqUpHlSif0AKscgWriTNi1UpA2aLjZASWRk6ZJzj7x3VwucMw0wnDkhv4OEb6Z+/6FciuExdxksTTqtlak6"+
        "j8R/o+wf0aDymvaGBso+a9OQhy94THT4jub/IjIOP5qfIHFpMJcKU4XnLC08tTjKFBLkxolQQNugD4NT+VXKVfRFXoGsFKNR"+
        "g4BHg1y2LHbXCmkFa3CtlRICdvaPhWB0cV/8QAIREAAgEDBAMBAAAAAAAAAAAAAQIDAAQRBRMhMRIygUH/2gAIAQIBAT8A2J"+
        "Ch2x0K0yd5hOtwfQ/aWBXGV5FTyJbabeMgUvHEW5FRrcLcEhsSeWW+1bTOYUy0ef3APdf/xAAjEQABAwQBBAMAAAAAAAAAAA"+
        "ACAQMEAAUREiEGEzGRQVJh/9oACAEDAQE/ABIN03XytXWE1GSO4xnB+vdKWPK81ZIgXG+WyO+RCw8+Anr9c80Ufplu1HEK3i"+
        "dud1RslRVLblPnlMVeYIQ7lKZAXO2hZDZUzoXI5x+V/9k=",
      "authorId": "07b17130-5c15-412f-882b-f3862de7a458"
  },
  {
      "id": 8,
      "dateCreated": "2020-11-30T23:07:11.8852501",
      "content": "Getting Around in Phu Yen: Once you travel to Phu Yen, you’ll need transportation to get to all the beautiful sights. Since they are quite spread out, some as far as 50 kilometers from Tuy Hoa, walking or biking is not an option for most travelers.",
      "likeJson": {
          "count": 2,
          "subjects": [
              {
                  "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
                  "Name": "Huynh Le"
              },
              {
                  "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
                  "Name": "Dang Bao"
              }
          ]
      },
      "commentJson": [
          {
              "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
              "Name": "Huynh Le",
              "Comment": ":)"
          },
          {
              "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
              "Name": "Dang Bao",
              "Comment": "woow!!!"
          }
      ],
      "authorName": "Bich Hoang",
      "authorThumb":"/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAMDAwMDAwMEBAMFBQQFBQcGBg"+
        "YGBwoHCAcIBwoPCgsKCgsKDw4QDQwNEA4YExERExgcGBYYHCIeHiIrKSs4OEsBAwMDAwMDAwQEAwUFBAUFBwYGBgYHCgcIBw"+
        "gHCg8KCwoKCwoPDhANDA0QDhgTERETGBwYFhgcIh4eIispKzg4S//CABEIAB4AKAMBIgACEQEDEQH/xAAZAAADAQEBAAAAAA"+
        "AAAAAAAAAFBggJBAf/2gAIAQEAAAAAzHJVrJgkuz6FRgrrzNYfBIQj1SlpkWP/xAAWAQEBAQAAAAAAAAAAAAAAAAAFBwL/2g"+
        "AIAQIQAAAA2U45LaV//8QAFwEAAwEAAAAAAAAAAAAAAAAAAAUIAv/aAAgBAxAAAADTlCVNLn//xAAmEAABAwQCAQQDAQAAAA"+
        "AAAAABAgMEAAUREgYxIQcTIlEyQVJh/9oACAEBAAE/AJCm3ntx1jqotifkmNspLXvOobSVnAG6gnY/QHZrnfoJw3h9mD9qvp"+
        "vy2JAYmgRVMFBKcgtLCsqqS0q0XC4R0ZWELW0CRgkDomiyo5+NQYrTJDzqdiOk1arg5DvtjuahlMOdHkBOuwAZcC+j31U/nD"+
        "PLxBj8emzLrGiD3ROmMqSzuBkJT7v5+eyajem99vc+XNu6xHckOLedWoYytZ2VXKOImxJDiHUuM7ahQ7NQW0qLhWj/AGrPZH"+
        "L9cYcGJru8vBJOqUpHlSif0AKscgWriTNi1UpA2aLjZASWRk6ZJzj7x3VwucMw0wnDkhv4OEb6Z+/6FciuExdxksTTqtlak6"+
        "j8R/o+wf0aDymvaGBso+a9OQhy94THT4jub/IjIOP5qfIHFpMJcKU4XnLC08tTjKFBLkxolQQNugD4NT+VXKVfRFXoGsFKNR"+
        "g4BHg1y2LHbXCmkFa3CtlRICdvaPhWB0cV/8QAIREAAgEDBAMBAAAAAAAAAAAAAQIDAAQRBRMhMRIygUH/2gAIAQIBAT8A2J"+
        "Ch2x0K0yd5hOtwfQ/aWBXGV5FTyJbabeMgUvHEW5FRrcLcEhsSeWW+1bTOYUy0ef3APdf/xAAjEQABAwQBBAMAAAAAAAAAAA"+
        "ACAQMEAAUREiEGEzGRQVJh/9oACAEDAQE/ABIN03XytXWE1GSO4xnB+vdKWPK81ZIgXG+WyO+RCw8+Anr9c80Ufplu1HEK3i"+
        "dud1RslRVLblPnlMVeYIQ7lKZAXO2hZDZUzoXI5x+V/9k=",
      "authorId": "07b17130-5c15-412f-882b-f3862de7a458"
  },
  {
      "id": 9,
      "dateCreated": "2020-11-30T23:07:11.8852563",
      "content": "Where to Stay in Phu Yen: As more people are discovering Phu Yen, more hotels, hostels, and homestays are popping up. This gives you several places to choose from in categories ranging from luxury to budget.Want to surprise your partner with a nice room ? Then you can splurge on the Vietstar Resort & Spa, a five - star property close to the city with a beautiful pool and sweeping views of the ocean. If you’re looking for a more budget - friendly place to stay which is also closer to the beach, have a look at the Sala Tuy Hoa Beach Hotel.This newly opened hotel is only a four - minute walk from the sea and offers great amenities and even an airport shuttle.",
      "likeJson": {
          "count": 2,
          "subjects": [
              {
                  "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
                  "Name": "Huynh Le"
              },
              {
                  "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
                  "Name": "Dang Bao"
              }
          ]
      },
      "commentJson": [
          {
              "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
              "Name": "Huynh Le",
              "Comment": ":)"
          },
          {
              "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
              "Name": "Dang Bao",
              "Comment": "woow!!!"
          }
      ],
      "authorName": "Bich Hoang",
      "authorThumb":"/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAMDAwMDAwMEBAMFBQQFBQcGBg"+
        "YGBwoHCAcIBwoPCgsKCgsKDw4QDQwNEA4YExERExgcGBYYHCIeHiIrKSs4OEsBAwMDAwMDAwQEAwUFBAUFBwYGBgYHCgcIBw"+
        "gHCg8KCwoKCwoPDhANDA0QDhgTERETGBwYFhgcIh4eIispKzg4S//CABEIAB4AKAMBIgACEQEDEQH/xAAZAAADAQEBAAAAAA"+
        "AAAAAAAAAFBggJBAf/2gAIAQEAAAAAzHJVrJgkuz6FRgrrzNYfBIQj1SlpkWP/xAAWAQEBAQAAAAAAAAAAAAAAAAAFBwL/2g"+
        "AIAQIQAAAA2U45LaV//8QAFwEAAwEAAAAAAAAAAAAAAAAAAAUIAv/aAAgBAxAAAADTlCVNLn//xAAmEAABAwQCAQQDAQAAAA"+
        "AAAAABAgMEAAUREgYxIQcTIlEyQVJh/9oACAEBAAE/AJCm3ntx1jqotifkmNspLXvOobSVnAG6gnY/QHZrnfoJw3h9mD9qvp"+
        "vy2JAYmgRVMFBKcgtLCsqqS0q0XC4R0ZWELW0CRgkDomiyo5+NQYrTJDzqdiOk1arg5DvtjuahlMOdHkBOuwAZcC+j31U/nD"+
        "PLxBj8emzLrGiD3ROmMqSzuBkJT7v5+eyajem99vc+XNu6xHckOLedWoYytZ2VXKOImxJDiHUuM7ahQ7NQW0qLhWj/AGrPZH"+
        "L9cYcGJru8vBJOqUpHlSif0AKscgWriTNi1UpA2aLjZASWRk6ZJzj7x3VwucMw0wnDkhv4OEb6Z+/6FciuExdxksTTqtlak6"+
        "j8R/o+wf0aDymvaGBso+a9OQhy94THT4jub/IjIOP5qfIHFpMJcKU4XnLC08tTjKFBLkxolQQNugD4NT+VXKVfRFXoGsFKNR"+
        "g4BHg1y2LHbXCmkFa3CtlRICdvaPhWB0cV/8QAIREAAgEDBAMBAAAAAAAAAAAAAQIDAAQRBRMhMRIygUH/2gAIAQIBAT8A2J"+
        "Ch2x0K0yd5hOtwfQ/aWBXGV5FTyJbabeMgUvHEW5FRrcLcEhsSeWW+1bTOYUy0ef3APdf/xAAjEQABAwQBBAMAAAAAAAAAAA"+
        "ACAQMEAAUREiEGEzGRQVJh/9oACAEDAQE/ABIN03XytXWE1GSO4xnB+vdKWPK81ZIgXG+WyO+RCw8+Anr9c80Ufplu1HEK3i"+
        "dud1RslRVLblPnlMVeYIQ7lKZAXO2hZDZUzoXI5x+V/9k=",
      "authorId": "07b17130-5c15-412f-882b-f3862de7a458"
  },
  {
      "id": 10,
      "dateCreated": "2020-11-30T23:07:11.8852629",
      "content": "Explore Tuy Hoa: The capital of Phu Yen province, Tuy Hoa is the center of cultural and economic life in the area. It is also home to some great historical spots such as the Ngoc Lang temple and the Nhan tower built by the Champa people. Take a few hours to check out the city before heading out into the countryside, it’s well worth it.",
      "likeJson": {
          "count": 2,
          "subjects": [
              {
                  "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
                  "Name": "Huynh Le"
              },
              {
                  "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
                  "Name": "Dang Bao"
              }
          ]
      },
      "commentJson": [
          {
              "Id": "24c902cd-4253-4b96-8f71-379d79e6cf04",
              "Name": "Huynh Le",
              "Comment": ":)"
          },
          {
              "Id": "02125d23-a7f1-44bd-b217-facec7d0cb8d",
              "Name": "Dang Bao",
              "Comment": "woow!!!"
          }
      ],
      "authorName": "Bich Hoang",
      "authorThumb":"/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAMDAwMDAwMEBAMFBQQFBQcGBg"+
        "YGBwoHCAcIBwoPCgsKCgsKDw4QDQwNEA4YExERExgcGBYYHCIeHiIrKSs4OEsBAwMDAwMDAwQEAwUFBAUFBwYGBgYHCgcIBw"+
        "gHCg8KCwoKCwoPDhANDA0QDhgTERETGBwYFhgcIh4eIispKzg4S//CABEIAB4AKAMBIgACEQEDEQH/xAAZAAADAQEBAAAAAA"+
        "AAAAAAAAAFBggJBAf/2gAIAQEAAAAAzHJVrJgkuz6FRgrrzNYfBIQj1SlpkWP/xAAWAQEBAQAAAAAAAAAAAAAAAAAFBwL/2g"+
        "AIAQIQAAAA2U45LaV//8QAFwEAAwEAAAAAAAAAAAAAAAAAAAUIAv/aAAgBAxAAAADTlCVNLn//xAAmEAABAwQCAQQDAQAAAA"+
        "AAAAABAgMEAAUREgYxIQcTIlEyQVJh/9oACAEBAAE/AJCm3ntx1jqotifkmNspLXvOobSVnAG6gnY/QHZrnfoJw3h9mD9qvp"+
        "vy2JAYmgRVMFBKcgtLCsqqS0q0XC4R0ZWELW0CRgkDomiyo5+NQYrTJDzqdiOk1arg5DvtjuahlMOdHkBOuwAZcC+j31U/nD"+
        "PLxBj8emzLrGiD3ROmMqSzuBkJT7v5+eyajem99vc+XNu6xHckOLedWoYytZ2VXKOImxJDiHUuM7ahQ7NQW0qLhWj/AGrPZH"+
        "L9cYcGJru8vBJOqUpHlSif0AKscgWriTNi1UpA2aLjZASWRk6ZJzj7x3VwucMw0wnDkhv4OEb6Z+/6FciuExdxksTTqtlak6"+
        "j8R/o+wf0aDymvaGBso+a9OQhy94THT4jub/IjIOP5qfIHFpMJcKU4XnLC08tTjKFBLkxolQQNugD4NT+VXKVfRFXoGsFKNR"+
        "g4BHg1y2LHbXCmkFa3CtlRICdvaPhWB0cV/8QAIREAAgEDBAMBAAAAAAAAAAAAAQIDAAQRBRMhMRIygUH/2gAIAQIBAT8A2J"+
        "Ch2x0K0yd5hOtwfQ/aWBXGV5FTyJbabeMgUvHEW5FRrcLcEhsSeWW+1bTOYUy0ef3APdf/xAAjEQABAwQBBAMAAAAAAAAAAA"+
        "ACAQMEAAUREiEGEzGRQVJh/9oACAEDAQE/ABIN03XytXWE1GSO4xnB+vdKWPK81ZIgXG+WyO+RCw8+Anr9c80Ufplu1HEK3i"+
        "dud1RslRVLblPnlMVeYIQ7lKZAXO2hZDZUzoXI5x+V/9k=",
      "authorId": "07b17130-5c15-412f-882b-f3862de7a458"
  }
  ]*/;

  public appUsers: AppUsers;
  constructor(private router: Router, private elementRef: ElementRef,@Inject(DOCUMENT) private doc ,private service: LoginService, private m_postService:PostService) { 
    this.loadPostData();
  }
  
  async ngOnInit() {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = "../assets/js/script.js";
    this.elementRef.nativeElement.appendChild(script);

    this.appUsers = new AppUsers();
    var user = await this.service.getUser();
    console.log(user["firstName"]+" "+user["lastName"]);
    this.appUsers.Avatar = user["avatar"];
  }

  loadPostData(){
      this.m_postService.getPostById("07b17130-5c15-412f-882b-f3862de7a458").subscribe(jsonData=>this.m_posts=jsonData);
  }

  getPath(){
    return this.router.url;
  }
  getImageMime(base64: string): string
  {
    return 'jpg';
  }
  getImageSource(base64: string): string
  {
    return `data:image/${this.getImageMime(base64)};base64,${base64}`; 
  }
  onLogout() {
    this.service.logout();
    this.router.navigateByUrl('/login');
  }
}
