import { Inter } from "next/font/google";
import "../globals.css";
import Menu from "../Components/Menu";
import { ChartPieIcon } from "@heroicons/react/24/outline";

const inter = Inter({ subsets: ["latin"] });

export const metadata = {
  title: "Create Next App",
  description: "Generated by create next app",
};

export default function RootLayoutAdm({ children }) {
  return (
    <html lang="pt-br">
      <body className={inter.className}>
        <div className="flex">
          <div className="flex flex-col w-64 px-4 py-8 border-r bg-gray-800">
            <Menu />
          </div>
          <div className="w-full h-screen p-4 m-8">{children}</div>
        </div>
      </body>
    </html>
  );
}
