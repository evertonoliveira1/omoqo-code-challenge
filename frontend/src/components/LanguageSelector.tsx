import MenuItem from '@material-ui/core/MenuItem';
import Select from '@material-ui/core/Select';
import React, { useState } from 'react';
import { FlagIcon } from "react-flag-kit";
import { useTranslation } from "react-i18next";
import styled from 'styled-components';

const LangName = styled.span`
  color: #000;
  margin-left: 20px;
`;

const LanguageSelector: React.FC = () => {
    const [selectedLanguage, setSelectedLanguage] = useState<string>(localStorage.getItem('savedLanguage') ?? 'en');
    const { i18n } = useTranslation();

    const handleLanguageChange = (event: React.ChangeEvent<{ value: unknown }>) => {
        const lang = event.target.value as string;
        setSelectedLanguage(lang);
        i18n.changeLanguage(lang);
        localStorage.setItem('savedLanguage', lang);
    };

    return (
        <div>
            <Select
                label="Languages"
                value={selectedLanguage}
                onChange={handleLanguageChange}
            >
                <MenuItem value="pt">
                    <FlagIcon code="BR" size={22} />
                    <LangName>Portuguese</LangName>
                </MenuItem>
                <MenuItem value="en">
                    <FlagIcon code="US" size={22} />
                    <LangName>English</LangName>
                </MenuItem>
            </Select>
        </div>
    );
};

export default LanguageSelector;
