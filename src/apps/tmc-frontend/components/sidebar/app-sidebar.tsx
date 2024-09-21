'use client';

import { Atom, BookOpen, Calendar, LifeBuoy, Send, Users2 } from 'lucide-react';

import { NavMain } from '@/components/sidebar/nav-main';
import { NavSecondary } from '@/components/sidebar/nav-secondary';
import { NavUser } from '@/components/sidebar/nav-user';
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  SidebarItem,
  SidebarLabel,
} from '@/components/ui/sidebar';
import Image from 'next/image';
import Link from 'next/link';
export const serviceMenus = {
  teams: [
    {
      name: 'TMC',
      logo: Atom,
      plan: 'Enterprise',
    },
  ],
  navMain: [
    {
      title: 'Home',
      url: '/service',
      icon: Calendar,
      isActive: true,
    },
  ],

  navSecondary: [
    {
      title: 'Support',
      url: '#',
      icon: LifeBuoy,
    },
    {
      title: 'Feedback',
      url: '#',
      icon: Send,
    },
  ],
  projects: [
    // {
    //   name: "Design Engineering",
    //   url: "#",
    //   icon: Frame,
    // },
    // {
    //   name: "Sales & Marketing",
    //   url: "#",
    //   icon: PieChart,
    // },
    // {
    //   name: "Travel",
    //   url: "#",
    //   icon: Map,
    // },
  ],
  searchResults: [
    {
      title: 'Routing Fundamentals',
      teaser:
        'The skeleton of every application is routing. This page will introduce you to the fundamental concepts of routing for the web and how to handle routing in Next.js.',
      url: '#',
    },
    {
      title: 'Layouts and Templates',
      teaser:
        'The special files layout.js and template.js allow you to create UI that is shared between routes. This page will guide you through how and when to use these special files.',
      url: '#',
    },
    {
      title: 'Data Fetching, Caching, and Revalidating',
      teaser:
        'Data fetching is a core part of any application. This page goes through how you can fetch, cache, and revalidate data in React and Next.js.',
      url: '#',
    },
    {
      title: 'Server and Client Composition Patterns',
      teaser:
        'When building React applications, you will need to consider what parts of your application should be rendered on the server or the client. ',
      url: '#',
    },
    {
      title: 'Server Actions and Mutations',
      teaser:
        'Server Actions are asynchronous functions that are executed on the server. They can be used in Server and Client Components to handle form submissions and data mutations in Next.js applications.',
      url: '#',
    },
  ],
};

export function AppSidebar() {
  return (
    <Sidebar>
      <SidebarHeader>
        {/* <TeamSwitcher teams={data.teams} /> */}
        <div className="flex items-center px-4">
          <Link href="/service" className="flex items-center gap-2 font-semibold">
            <Image src="/images/main/logo_clean.png" alt="logo" width={40} height={40} />
            <span className="">TMC</span>
          </Link>
        </div>
      </SidebarHeader>
      <SidebarContent>
        <SidebarItem>
          <SidebarLabel>Serviço</SidebarLabel>
          <NavMain items={serviceMenus.navMain} searchResults={serviceMenus.searchResults} />
        </SidebarItem>
        {/* <SidebarItem>
          <SidebarLabel>Projects</SidebarLabel>
          <NavProjects projects={data.projects} />
        </SidebarItem> */}
        <SidebarItem className="mt-auto">
          <SidebarLabel>Help</SidebarLabel>
          <NavSecondary items={serviceMenus.navSecondary} />
        </SidebarItem>
        {/* <SidebarItem>
          <StorageCard />
        </SidebarItem> */}
      </SidebarContent>
      <SidebarFooter>
        {/* <NavUser /> */}
      </SidebarFooter>
    </Sidebar>
  );
}
