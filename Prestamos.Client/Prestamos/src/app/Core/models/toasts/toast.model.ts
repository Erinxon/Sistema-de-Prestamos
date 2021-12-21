
export type tipoToast = 'success' | 'error';

export interface ToastModel {
  title: string;
  body: string;
  tipo: tipoToast;
}