"use client";
import React, { useEffect, useState } from "react";
import Input from "../Components/Input";
import Select from "../Components/Select";
import AutoComplete from "../Components/AutoComplete";
import Button from "../Components/Button";
import Ahref from "../Components/Link";
import { useSearchParams } from "next/navigation";
import Form from "../Data/cadastro";
import moment from "moment";

const medico = [
  "paciente 1",
  "paciente 2",
  "paciente 3",
  "paciente 4",
  "paciente 1",
  "paciente 2",
  "paciente 3",
  "paciente 4",
  "paciente 1",
  "paciente 2",
  "paciente 3",
  "paciente 4",
];

const getSelectedVal = (value) => {
  console.log(value);
};

const getChanges = (value) => {
  console.log(value);
};

function Agenda() {
  const param = useSearchParams();
  const [horario, setHorario] = useState(null);
  const [data, setData] = useState(null);
  const dentista = Form();

  useEffect(() => {
    if (param.get("horario") != null) {
      const hora = param.get("horario");
      const data = param.get("data");
      dentista.value = param.get("medico");
      setHorario(hora);
      setData(data);
    }
  }, []);

  return (
    <>
      <div className="mt-24 w-full">
        <div className="flex flex-row gap-2">
          <span className="text-2xl">Agendar paciente</span>
        </div>
        <div className="grid grid-cols-1 gap-4 py-5 ">
          <Select placeholder={"Selecione um dentista"} {...dentista} />
          <AutoComplete
            data={medico}
            onSelected={getSelectedVal}
            onChange={getChanges}
            placeholder={"Nome do paciente"}
          />
          <Select placeholder={"Selecione o procedimento"} />
          <Input type={"date"} value={moment(data).format("YYYY-MM-DD")} />
          <Select placeholder={"Selecione um horario"} value={horario} />
        </div>
        <div className="flex flex-col gap-2 md:flex-row md:justify-row lg:flex-row xl:flex-row xl:justify-row">
          <Button>Agendar</Button>
          <Ahref link={"/"}>Voltar</Ahref>
        </div>
      </div>
    </>
  );
}

export default Agenda;
