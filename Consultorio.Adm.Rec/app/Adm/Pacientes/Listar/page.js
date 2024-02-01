"use client";
import GenericTable from "@/app/Components/GenericTable";
import Ahref from "@/app/Components/Link";
import React, { useEffect, useState } from "react";
import { PacienteListar } from "@/Data/Controller/PacienteController";

function Lista() {
  useEffect(() => {
    ListarTodos();
  }, []);

  async function ListarTodos() {
    const response = await PacienteListar();
    if (response.sucesso) {
      setData(response.dados.dados);
    } else {
      if (response.errors.length > 1) {
        setErros(response.errors);
      } else {
        setErros([response.message]);
      }
    }
  }

  const [errors, setErros] = useState([]);
  const [typeAlert, settypeAlert] = useState("");
  const [data, setData] = useState([]);
  return (
    <>
      <div className="mt-24">
        <div className="flex flex-col gap-2 md:flex-row md:justify-between lg:justify-between xl:flex-row xl:justify-between">
          <span className="text-2xl">Lista de pacientes</span>
          <Ahref link={"/Adm/Pacientes/Cadastrar"}>Cadastrar paciente</Ahref>
        </div>
      </div>
      <div className="mt-5 flex">
        {data && (
          <GenericTable
            titulo={["Nome Paciente", "Data de nascimento", "Nome da Mãe"]}
            colunas={data}
            objetos={["nomePaciente", "dataNacimento", "nomeMae"]}
            acao={true}
          />
        )}
      </div>
    </>
  );
}

export default Lista;
