import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PageStatic } from './../_core/data-repository/page'
import { PagesService } from './../_core/services/page.service';
@Injectable({
    providedIn:'root'
})
export class PageUrl{
    public m_returnUrl: string;
    constructor(private m_route: ActivatedRoute, private m_router: Router,private PService:PagesService){}
    public async getNavigation( id) {
        this.m_returnUrl = this.m_route.snapshot.queryParams['returnUrl'] || '/main/fanpage/'+id;
        PageStatic.Id = id
        const result = await this.PService.getPageById(PageStatic.Id);
        PageStatic.Name = result["name"]
        PageStatic.Avatar = result["avatar"]
        PageStatic.Background =result["background"]
        this.m_router.navigateByUrl(this.m_returnUrl, {skipLocationChange:true});
    }
}