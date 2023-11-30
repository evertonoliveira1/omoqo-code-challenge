import i18next from "i18next";
import { initReactI18next } from "react-i18next";

import translationEnglish from "./translations/english.json";
import translationPortuguese from "./translations/portuguese.json";

const resources = {
    en: {
        translation: translationEnglish,
    },
    pt: {
        translation: translationPortuguese,
    },
};

i18next
    .use(initReactI18next)
    .init({
        resources,
        lng: localStorage.getItem('savedLanguage') ?? "en",
    });

export default i18next;