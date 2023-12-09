import Button from "@/app/Components/Button";
import Input from "@/app/Components/Input";
import InputMaks from "@/app/Components/InputMaks";
import Ahref from "@/app/Components/Link";
import React from "react";

function Cadastrar() {
  return (
    <>
      <div className="mt-24">
        <div className="w-full flex flex-col gap-2 md:flex-row md:justify-between lg:justify-between xl:flex-row xl:justify-between">
          <span className="text-2xl">Cadastro de pacientes</span>
        </div>
      </div>
      <div className="mt-5">
        <div className="grid grid-cols-1 gap-5">
          <Input placeholder={"Nome completo do paciente"} />
          <InputMaks mask={"999.999.999-99"} placeholder={"CPF"} />
          <Input type={"data"} placeholder={"Data de nascimento"} />
          <InputMaks mask={"(99) 99999-9999"} placeholder={"Telefone"} />
          <Input placeholder={"Endereço"} />
          <Input placeholder={"Bairro"} />
        </div>
      </div>
      <div className="flex gap-5 mt-5">
        <Button>Cadastrar</Button>
        <Ahref link={"/Pacientes/Listar"}>Voltar</Ahref>
      </div>
    </>
  );
}

export default Cadastrar;
