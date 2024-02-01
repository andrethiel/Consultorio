import React from "react";
import {
  BookOpenIcon,
  ChartPieIcon,
  HomeIcon,
  UserIcon,
} from "@heroicons/react/24/outline";
import Image from "next/image";

function Menu() {
  return (
    <div className="h-full px-3 py-4 overflow-y-auto">
      <Image src="/Logo.png" width={500} height={500} alt="" />
      <aside className="mt-5">
        <ul className="space-y-2 font-medium ">
          <li>
            <a
              href="/Adm"
              className="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group"
            >
              <HomeIcon className="h-6 w-6" aria-hidden="true" />
              <span className="ms-3">Inicio</span>
            </a>
          </li>
          <li>
            <a
              href="/Adm/Consulta"
              className="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group"
            >
              <BookOpenIcon className="h-6 w-6" aria-hidden="true" />
              <span className="ms-3">Agendar</span>
            </a>
          </li>
          <li>
            <a
              href="/Adm/Pacientes/Listar"
              className="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700 group"
            >
              <UserIcon className="h-6 w-6" aria-hidden="true" />
              <span className="ms-3">Pacientes</span>
            </a>
          </li>
        </ul>
      </aside>
    </div>
  );
}

export default Menu;
