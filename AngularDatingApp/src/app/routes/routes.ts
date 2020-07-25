import { Routes } from '@angular/router';
import { HomeComponent } from './../home/home.component';
import { MemberListComponent } from './../members/member-list/member-list.component';
import { MessagesComponent } from './../messages/messages.component';
import { ListsComponent } from './../lists/lists.component';
import { AuthGuard } from '../_guards/auth.guard';
import { MemberDetailsComponent } from '../members/member-details/member-details.component';
import { MemberDetailResolver } from '../_resolvers/member-detail.resolver';
import { MemberListResolver } from '../_resolvers/member-list.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent, resolve: {user: MemberListResolver} },
            { path: 'members/:id', component: MemberDetailsComponent, resolve: {user: MemberDetailResolver} },
            { path: 'messages', component: MessagesComponent },
            { path: 'lists', component: ListsComponent },
        ]
    },
    // { path: 'members', component: MemberListComponent, canActivate: [AuthGuard] },
    // { path: 'messages', component: MessagesComponent, canActivate: [AuthGuard]  },
    // { path: 'lists', component: ListsComponent, canActivate: [AuthGuard]  },
    { path: '**', redirectTo: '', pathMatch: 'full' },
]