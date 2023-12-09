import GenericTable from "@/app/Components/GenericTable";
import Ahref from "@/app/Components/Link";
import React from "react";

const paciente = [
  {
    Id: 1,
    Paciente: "paciente 1",
    dataNascimento: "29/06/1991",
  },
  {
    Id: 2,
    Paciente: "paciente 2",
    dataNascimento: "29/06/1991",
  },
];

function Listar() {
  return (
    <>
      <div className="mt-24">
        <div className="w-full flex flex-col gap-2 md:flex-row md:justify-between lg:justify-between xl:flex-row xl:justify-between">
          <span className="text-2xl">Lista de pacientes</span>
          <Ahref link={"/Pacientes/Cadastrar"}>Cadastrar paciente</Ahref>
        </div>
      </div>
      <div className="mt-5 flex">
        <GenericTable
          titulo={["Nome Paciente", "Data de nascimento"]}
          colunas={paciente}
        />
      </div>
    </>
  );
}

export default Listar;
