import React, { FC, useEffect, useState } from "react";
import { Roles } from "../../constants/roles";

export interface ISidebar {
  id: string;
  label: string;
  isHeader?: boolean;
  icon?: string;
  link?: string;
  state?: boolean;
  subItems?: ISubItems[];
  roles?: string[];
  click?: (e: React.MouseEvent<HTMLLinkElement>) => void;
}

export interface ISubItems {
  id: string;
  label: string;
  link: string;
  parentId: string;
}

const AdminSidebarData: FC = (): ISidebar[] => {
  const [currentState, setCurrentState] = useState<string>("");

  const [isDashboard, setIsDashboard] = useState<string>("");
  const [isCatalog, setIsCatalog] = useState<string>("");
  const [isSales, setIsSales] = useState<string>("");
  const [isNews, setIsNews] = useState<string>("");
  const [isCustomer, setIsCustomer] = useState<string>("");
  const [isSeller, setIsSeller] = useState<string>("");
  const [isWidget, setIsWidget] = useState<string>("");

  useEffect(() => {
    document.body.classList.remove("twocolumn-panel");

    if (currentState === "Dashboard") {
      setIsDashboard("");
      // document.body.classList.add("twocolumn-panel");
    }
    if (currentState !== "Catalog") {
      setIsCatalog("");
    }
    if (currentState !== "Sales") {
      setIsSales("");
    }
    if (currentState !== "News") {
      setIsNews("");
    }
    if (currentState !== "Customer") {
      setIsCustomer("");
    }
    if (currentState !== "Seller") {
      setIsSeller("");
    }
  }, [
    currentState,
    isDashboard,
    isCatalog,
    isSales,
    isNews,
    isCustomer,
    isWidget,
  ]);

  function updateIconSidebar(e: React.MouseEvent<HTMLLinkElement>) {
    if (e && e.target && e.currentTarget.getAttribute("subitems")) {
      const ul = document.getElementById("two-column-menu");
      const iconItems = ul.querySelector(".nav-icon.active");

      let activeIconItems: Element[] = [...iconItems];

      activeIconItems.forEach((item) => {
        item.classList.remove("active");

        const id = item.getAttribute("subitems");

        if (document.getElementById(id)) {
          document.getElementById(id).classList.remove("show");
        }
      });
    }
  }

  return [
    {
      id: "menuHeader",
      label: "Меню",
      isHeader: true,
    },
    {
      id: "dashboard",
      label: "Дашборд",
      icon: "ri-dashboard-2-line",
      link: "/admin/admin-dashboard",
      state: !!isDashboard,
      click: function (e: React.MouseEvent<HTMLLinkElement>) {
        e.preventDefault();
        setCurrentState("Dashboard");
        setIsDashboard("Dashboard");
      },
    },
    {
      id: "adminMenu",
      label: "Администрирование",
      isHeader: true,
    },
    {
      id: "catalog",
      label: "Каталог",
      icon: "ri-article-line",
      link: "/#",
      state: !!isCatalog,
      click: function (e: React.MouseEvent<HTMLLinkElement>) {
        e.preventDefault();
        setIsCatalog("Catalog");
        setCurrentState("Catalog");
        updateIconSidebar(e);
      },
      subItems: [
        {
          id: "categories",
          link: "/admin/categories",
          label: "Категории",
          parentId: "catalog",
        },
        {
          id: "products",
          link: "/admin/products",
          label: "Управление продуктами",
          parentId: "catalog",
        },
        {
          id: "products_review",
          link: "/admin/products-review",
          label: "Обзоры продуктов",
          parentId: "catalog",
        },
        {
          id: "manufactures",
          link: "/admin/manufactures",
          label: "Производители",
          parentId: "catalog",
        },
      ],
    },
    {
      id: "sales",
      label: "Продажи",
      icon: "ri-pie-chart-line",
      link: "/#",
      state: !!isSales,
      click: function (e: React.MouseEvent<HTMLLinkElement>) {
        e.preventDefault();
        setIsSales("Sales");
        setCurrentState("Sales");
        updateIconSidebar(e);
      },
      subItems: [
        {
          id: "orders",
          label: "Заказы",
          link: "/admin/orders",
          parentId: "sales",
        },
        {
          id: "shipments",
          label: "Отгрузки",
          link: "/admin/shipments",
          parentId: "sales",
        },
      ],
    },
    {
      id: "news",
      label: "Новости",
      icon: "ri-newspaper-line",
      link: "/#",
      // roles: [Roles.Admin],
      state: !!isNews,
      click: function (e: React.MouseEvent<HTMLLinkElement>) {
        e.preventDefault();
        setIsNews("News");
        setCurrentState("News");
        updateIconSidebar(e);
      },
      subItems: [
        {
          id: "banners",
          label: "Банеры",
          link: "/admin/news/banners",
          parentId: "news",
        },
        {
          id: "promotions",
          label: "Акции",
          link: "/admin/news/promotions",
          parentId: "news",
        },
        {
          id: "tags",
          label: "Аттрибуты",
          link: "/admin/news/tags",
          parentId: "news",
        },
      ],
    },
    {
      id: "usersMenu",
      label: "Пользователи",
      isHeader: true,
      // roles: [Roles.Admin],
    },
    {
      id: "customers",
      label: "Сотрудники",
      icon: "ri-customer-service-line",
      link: "/#",
      // roles: [Roles.Admin],
      state: !!isCustomer,
      click: function (e: React.MouseEvent<HTMLLinkElement>) {
        e.preventDefault();
        setIsCustomer("Customer");
        setCurrentState("Customer");
        updateIconSidebar(e);
      },
      subItems: [
        {
          id: "customer",
          label: "Сотрудники",
          link: "/admin/customer/employees",
          parentId: "customers",
        },
        {
          id: "test",
          label: "test",
          link: "/admin/customer/test",
          parentId: "customers",
        },
      ],
    },
    {
      id: "sellers",
      label: "Продавцы",
      icon: "ri-file-user-line",
      link: "/#",
      // roles: [Roles.Admin],
      state: !!isSeller,
      click: function (e: React.MouseEvent<HTMLLinkElement>) {
        e.preventDefault();
        setIsSeller("Seller");
        setCurrentState("Seller");
        updateIconSidebar(e);
      },
      subItems: [
        {
          id: "test",
          label: "test",
          link: "/admin/news/banners",
          parentId: "sellers",
        },
      ],
    },
    {
      id: "widgets",
      label: "Widgets",
      icon: "ri-honour-line",
      link: "/widgets",
      state: !!isWidget,
      click: function (e: React.MouseEvent<HTMLLinkElement>) {
        e.preventDefault();
        setCurrentState("Widgets");
        setIsWidget("Widgets");
      },
    },
  ];
};

export default AdminSidebarData;
